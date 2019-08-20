using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities
{
    public class KPI
    {
        [Key]
        public int KPIId { get; set; }
        public Guid UniqueId { get; set; }

        public string Name { get; set; }
        public int Category { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [DisplayName("Region")]
        public int RegionId { get; set; }
        [DisplayName("Quarter")]
        public int Quarter { get; set; }
        [DisplayName("Year")]
        [DisplayFormat]
        public int Year { get; set; }
        public DateTime DateAndTime { get; set; }
        [DisplayName("User")]
        public int UserId { get; set; }
        [DisplayName("Land Area Planted (ha)")]
        public int Hectar { get; set; }
        [DisplayName("Number of Farms")]
        public int NoOfFarms { get; set; }
        [DisplayName("Number of Trees")]
        public int NoOfTrees { get; set; }
        [DisplayName("Volume of production(kg)")]
        public int Production { get; set; }
        [DisplayName("Variety Use")]
        public string Variety { get; set; }
        [DisplayName("Volume processed for Local Market")]
        public int VolumeMarket { get; set; }
        [DisplayName("Volume processed for International Market")]
        public int VolumeInternational { get; set; }
        [DisplayName("Volume sold for Local Market")]
        public int VolumeSoldMarket { get; set; }
        [DisplayName("Volume sold for International Market")]
        public int VolumeSoldInternational { get; set; }
        [DisplayName("Number of farmers/growers (Male)")]
        public int Male { get; set; }
        [DisplayName("Number of farmers/growers (Female)")]
        public int Female { get; set; }
        [DisplayName("Municipalities Engaged")]
        public int MunicipalitiesEngaged { get; set; }
        [DisplayName("Number of nurseries ")]
        public int NumberOfNurseries { get; set; }
        [DisplayName("Number of postharvest facilities utilized")]
        public int NoOfPostharvest { get; set; }
        [DisplayName("Income generated")]
        public int IncomeGenerated { get; set; }
        [DisplayName("Number of SMEs created")]
        public int SMEs { get; set; }
        [DisplayName("Number of jobs created")]
        public int JobsCreated { get; set; }
        [DisplayName("Number of funding assistance, loans approved and released")]
        public int NoOfFundingAssistance { get; set; }
        [DisplayName("Number of funding institutions/organizations")]
        public int NoOfFundingInstitutions { get; set; }
        [DisplayName("Number of policy reforms instituted")]
        public int NoOfPoliciReforms { get; set; }
        [DisplayName("Number of seedlings distributed DA")]
        public int DA { get; set; }
         [DisplayName("Number of seedlings distributed DENR-NGP")]
        public int DENR_NGP { get; set; }
         [DisplayName("Number of seedlings distributed PCA-Kaanib")]
        public int PCA_Kaanib { get; set; }
         [DisplayName("Number of seedlings distributed DAR")]
        public int DAR { get; set; }
         [DisplayName("Number of techno trainings/seminar conducted")]
        public int Trainings { get; set; }
         [DisplayName("Number of farmers trained ")]
        public int FarmesrsTrained { get; set; }
         [DisplayName("Number of IEC materials distributed")]
        public int IECMaterials { get; set; }
        [DisplayName("Number of linkages established Local")]
        public int LinkagesLocal { get; set; }
        [DisplayName("Number of linkages established International")]
        public int LinkagesInternational { get; set; }
        [DisplayName("Percentage of farmers who apply pests and diseases management")]
        public int DiseasesManagement { get; set; }
        [DisplayName("Percentage of farmers who apply Good Agricultural Practices( GAPs)")]
        public int GoodAgriculturalPractices { get; set; }
        [DisplayName("Number of cacao farms certified")]
        public int CacaoFarmsCertified { get; set; }
        [DisplayName("Number of nurseries accredited ")]
        public int NurseriesAccredited { get; set; }
        [DisplayName("Number of model farms and learning/demo sites established ")]
        public int ModelFarms { get; set; }
        [DisplayName("Number of research works developed")]
        public int ResearchWorkDeveloped { get; set; }




    }
}
