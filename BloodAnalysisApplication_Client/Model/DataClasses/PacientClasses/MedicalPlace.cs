using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses
{
    public class MedicalPlace
    {
        public int PlaceNumber { get; set; }

        public bool Attachment { get; set; }

        public MedicalPlace(int _PlaceNumber, bool _Attachment)
        {
            this.PlaceNumber = _PlaceNumber;
            this.Attachment = _Attachment;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                MedicalPlace IsEqualMedicalPlace = (MedicalPlace)obj;
                return (this.PlaceNumber == IsEqualMedicalPlace.PlaceNumber) &&
                    (this.Attachment == IsEqualMedicalPlace.Attachment);
            }
        }

        public override int GetHashCode()
        {
            return this.PlaceNumber.GetHashCode() +
                this.Attachment.GetHashCode();
        }

        public string AttachmentMessage()
        {
            if (this.Attachment)
                return "Участок прикреплен к клинике";
            else
                return "Участок не прикреплен к клинике";
        }
    }
}