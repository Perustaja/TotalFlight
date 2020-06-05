using System.ComponentModel.DataAnnotations;
using TotalFlight.Domain.Events;
using TotalFlight.Domain.Exceptions.Aircraft;
using TotalFlight.Domain.SharedKernel;
using TotalFlight.Domain.Validators;

namespace TotalFlight.Domain.Entities.AircraftAggregate
{
    /// <summary>
    /// Contains stateful information and information used solely for maintenance logs (models, serial nums).
    /// </summary>
    public class Aircraft : Entity
    {
        [StringLength(50)]
        public string Id { get; private set; }
        public string Model { get; private set; }
        [Range(1000, 9999)]
        public int Year { get; private set; }
        [Range(0, 1000)]
        public int Places { get; private set; }
        public string SerialNum { get; private set; }
        public string Eng1Model { get; private set; } 
        public string Eng2Model { get; private set; } 
        public string Prop1Model { get; private set; } 
        public string Prop2Model { get; private set; } 
        public string Eng1SerialNum { get; private set; }
        public string Eng2SerialNum { get; private set; }
        public string Prop1SerialNum { get; private set; }
        public string Prop2SerialNum { get; private set; }
        public bool IsGrounded { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDispatched { get; private set; }
        public bool IsSoftDeleted { get; private set; }
        public string ImagePath { get; private set; }
        public string ImageThumbPath { get; private set; }
        public AircraftTimes Times { get; private set; } // Named for ease of use along with Options
        public AircraftOptions Options { get; private set; }
        protected Aircraft() { } // Required by EF Core
        public Aircraft(string id, string model, int year, int places, AircraftTimes times,
        AircraftOptions opts)
        {
            Id = id;
            SetRequiredDetails(model, year, places);
            IsGrounded = false;
            IsSoftDeleted = false;
            IsActive = false;
            opts.SetId(id);
            times.SetId(id);
            Options = opts;
            Times = times;
            this.Validate();
        }
        public void SetRequiredDetails(string model, int year, int places)
        {
            Model = model;
            Year = year;
            Places = places;
        }
        public void SetOptionalDetails(string serNum, string eng1Mod, string eng2Mod, string prop1Mod, 
        string prop2Mod, string eng1SerNum, string eng2SerNum, string prop1SerNum, string prop2SerNum)
        {
            SerialNum = serNum;
            Eng1Model = eng1Mod;
            Eng2Model = eng2Mod;
            Prop1Model = prop1Mod;
            Prop2Model = prop2Mod;
            Eng1SerialNum = eng1SerNum;
            Eng2SerialNum = eng2SerNum;
            Prop1SerialNum = prop1SerNum;
            Prop2SerialNum = prop2SerNum;
        }
        public void SoftDelete()
        {
            IsSoftDeleted = IsDispatched ? throw new EditWhileDispatchedException(Id, nameof(SoftDelete))
            : true;
        }
        public void Activate() => IsActive = true;
        public void Deactivate()
        {
            IsActive = IsDispatched ? throw new EditWhileDispatchedException(Id, nameof(Deactivate))
            : false;
        }
        public void Ground() => IsGrounded = true;
        public void Dispatch() => IsDispatched = true;
        public void UnDispatch() => IsDispatched = false;
        public void SetImage(string path, string thumbPath) 
        {
            ImagePath = path;
            ImageThumbPath = thumbPath;
        }
        /// <summary>
        /// Sets times/options without propogating changes. If AircraftTotalTime's target is edited, no
        /// changes will be made to it.
        /// </summary>
        public void SetConfiguration(AircraftTimes times, AircraftOptions opts)
        {
            if (IsDispatched)
                throw new EditWhileDispatchedException(Id, nameof(SetConfiguration));
            Options = opts;
            Times = times;
            this.Validate();
            DomainEvents.Add(new AircraftTimesChangedDomainEvent(Times));
        }
        /// <summary>
        /// Updates times, propogating changes. The positive difference between the old and 
        /// new property will be added to AircraftTotalTime if it is targeting that property. If
        /// any new times are less than the current times, an exception will be thrown.
        /// </summary>
        public void UpdateTimes(decimal eng1Curr, decimal? eng2Curr, decimal? elecHobbs, 
        decimal? airtimeCurr, int? cycles)
        {
            Times.UpdateTimes(eng1Curr, eng2Curr, elecHobbs, airtimeCurr, cycles);
            if (Options.IsTwin) {
                Times.UpdateTwinTimes(eng2Curr.Value);
            }
            this.Validate();
            DomainEvents.Add(new AircraftTimesChangedDomainEvent(Times));
        }
    }
}