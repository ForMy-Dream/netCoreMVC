using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class BLXX
    {
        [JsonProperty("AdmissionNo")]
        public string AdmissionNo { get; set; }

        [JsonProperty("IsDischarge")]
        public string IsDischarge { get; set; }

        [JsonProperty("SettlementNo")]
        public string SettlementNo { get; set; }

        [JsonProperty("MedicalRecordNo")]
        public string MedicalRecordNo { get; set; }

        [JsonProperty("HospitalizedNo")]
        public string HospitalizedNo { get; set; }

        [JsonProperty("AdmissionDate")]
        public string AdmissionDate { get; set; }

        [JsonProperty("DischargeDate")]
        public string DischargeDate { get; set; }

        [JsonProperty("PatientId")]
        public string PatientId { get; set; }

        [JsonProperty("PatientName")]
        public string PatientName { get; set; }

        [JsonProperty("PatientGender")]
        public string PatientGender { get; set; }

        [JsonProperty("PatientBirthday")]
        public string PatientBirthday { get; set; }

        [JsonProperty("PatientAge")]
        public int PatientAge { get; set; }

        [JsonProperty("NewbornWeight")]
        public int NewbornWeight { get; set; }

        [JsonProperty("NewbornAge")]
        public int NewbornAge { get; set; }

        [JsonProperty("PatientIdNo")]
        public string PatientIdNo { get; set; }

        [JsonProperty("InsuranceType")]
        public string InsuranceType { get; set; }

        [JsonProperty("PayType")]
        public string PayType { get; set; }

        [JsonProperty("DeptName")]
        public string DeptName { get; set; }

        [JsonProperty("OutZoneName")]
        public string OutZoneName { get; set; }

        [JsonProperty("OutWard")]
        public string OutWard { get; set; }

        [JsonProperty("OutBedNo")]
        public string OutBedNo { get; set; }

        [JsonProperty("InHospitalDates")]
        public int InHospitalDates { get; set; }

        [JsonProperty("DoctorGroupName")]
        public string DoctorGroupName { get; set; }

        [JsonProperty("DoctorName")]
        public string DoctorName { get; set; }

        [JsonProperty("LeaveHospitalType")]
        public string LeaveHospitalType { get; set; }

        [JsonProperty("InHospitalTimes")]
        public int InHospitalTimes { get; set; }

        [JsonProperty("InDeptName")]
        public string InDeptName { get; set; }

        [JsonProperty("TransDeptName")]
        public string TransDeptName { get; set; }

        [JsonProperty("DischargeOutcome")]
        public string DischargeOutcome { get; set; }

        [JsonProperty("CodeType")]
        public string CodeType { get; set; }

        [JsonProperty("Zzd")]
        public string Zzd { get; set; }

        [JsonProperty("ZzdName")]
        public string ZzdName { get; set; }

        [JsonProperty("ZdList")]
        public List<string> ZdList { get; set; }

        [JsonProperty("ZdNameList")]
        public List<string> ZdNameList { get; set; }

        [JsonProperty("ZssName")]
        public string ZssName { get; set; }

        [JsonProperty("SsList")]
        public List<string> SsList { get; set; }

        [JsonProperty("SsNameList")]
        public List<string> SsNameList { get; set; }

        [JsonProperty("ZyZzd")]
        public string ZyZzd { get; set; }

        [JsonProperty("ZyZzdName")]
        public string ZyZzdName { get; set; }

        [JsonProperty("ZyZdList")]
        public List<string> ZyZdList { get; set; }

        [JsonProperty("ZyZdNameList")]
        public List<string> ZyZdNameList { get; set; }

        [JsonProperty("AnaesthesiaType")]
        public string AnaesthesiaType { get; set; }

        [JsonProperty("ZssLevel")]
        public string ZssLevel { get; set; }

        [JsonProperty("SsLevelList")]
        public List<string> SsLevelList { get; set; }

        [JsonProperty("TotalFee")]
        public double TotalFee { get; set; }

        [JsonProperty("DrugFee")]
        public double DrugFee { get; set; }

        [JsonProperty("MaterialFee")]
        public double MaterialFee { get; set; }

        [JsonProperty("TreatmentFee")]
        public double TreatmentFee { get; set; }

        [JsonProperty("OtherFee")]
        public double OtherFee { get; set; }

        [JsonProperty("ExaminationFee")]
        public double ExaminationFee { get; set; }

        [JsonProperty("AntiFee")]
        public double AntiFee { get; set; }

        [JsonProperty("SynthesizeFee")]
        public double SynthesizeFee { get; set; }

        [JsonProperty("CashAmount")]
        public double CashAmount { get; set; }

        [JsonProperty("ZyAmount")]
        public double ZyAmount { get; set; }

        [JsonProperty("ZyTreatAmount")]
        public double ZyTreatAmount { get; set; }

        [JsonProperty("ZyServAmount")]
        public double ZyServAmount { get; set; }

        [JsonProperty("DrugList")]
        public List<string> DrugList { get; set; }

        [JsonProperty("InstrumentList")]
        public List<string> InstrumentList { get; set; }

        [JsonProperty("OpLevel")]
        public int OpLevel { get; set; }

        [JsonProperty("TreatType")]
        public int TreatType { get; set; }

        [JsonProperty("AreaCode")]
        public string AreaCode { get; set; }

        [JsonProperty("AreaName")]
        public string AreaName { get; set; }

        [JsonProperty("InsurancePayType")]
        public int InsurancePayType { get; set; }

        [JsonProperty("SettleDate")]
        public string SettleDate { get; set; }
    }
}
