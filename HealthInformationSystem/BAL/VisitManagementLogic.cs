﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthInformationProgram.CustomExtensions;
using HealthInformationProgram.Models;
using HealthInformationProgram.Data;
using HealthInformationProgram.Data.Tables;

namespace HealthInformationProgram.BAL
{
    public class VisitManagementLogic
    {
        public OfficeVisitModel FindVisitByVisitId(string visitId)
        {
            OfficeVisitModel officeVisitModel = null;

            visitId = visitId.MakeDBFriendly();
            decimal decimalVisitId = 0;
            if (decimal.TryParse(visitId, out decimalVisitId))
            {
                OfficeVisitData officeVisitData = new OfficeVisitData();
                officeVisitModel = officeVisitData.GetVisit(decimalVisitId);
            }

            return officeVisitModel;
        }

        public List<SelectListItem> DiagnosisAsSelectListItems()
        {
            List<SelectListItem> diagnosisAsSelectListItems = new List<SelectListItem>();

            DiagnosisData diagnosisData = new DiagnosisData();
            List<DiagnosisModel> allDiagnosis = diagnosisData.GetAllDiagnosis();

            foreach(DiagnosisModel diagnosisModel in allDiagnosis)
            {
                SelectListItem diagnoisisAsSelectListItem = new SelectListItem();

                diagnoisisAsSelectListItem.Text = diagnosisModel.DiagnosisDescription;
                diagnoisisAsSelectListItem.Value = diagnosisModel.DiagnosisId;

                diagnosisAsSelectListItems.Add(diagnoisisAsSelectListItem);
            }

            return diagnosisAsSelectListItems;
        }

        public List<SelectListItem> SupplimentalDiagnosisAsSelectListItems(decimal DiagnosisId)
        {
            List<SelectListItem> supplimentalDiagnosisAsSelectListItems = new List<SelectListItem>();

            DiagnosisData diagnosisData = new DiagnosisData();
            List<SupplementalDiagnosisModel> allSupplementalDiagnosis = diagnosisData.GetAllSupplementalDiagnosisForGivenDiagnosisId(DiagnosisId);

            foreach (SupplementalDiagnosisModel supplementalDiagnosisModel in allSupplementalDiagnosis)
            {
                SelectListItem supplementalDiagnoisisAsSelectListItem = new SelectListItem();

                supplementalDiagnoisisAsSelectListItem.Text = supplementalDiagnosisModel.SupplementalDiagnosisDescription;
                supplementalDiagnoisisAsSelectListItem.Value = supplementalDiagnosisModel.SupplementalDiagnosisId;

                supplimentalDiagnosisAsSelectListItems.Add(supplementalDiagnoisisAsSelectListItem);
            }

            return supplimentalDiagnosisAsSelectListItems;
        }

        public List<SelectListItem> GendersAsSelectListItems()
        {
            List<SelectListItem> gendersAsSelectListItems = new List<SelectListItem>();

            var repo = new HealthInformationProgram.Data.Repositories.LookupGenderRepository();
            List<lkup_gndr> allGenders = repo.GetAll();

            foreach (lkup_gndr gender in allGenders)
            {
                SelectListItem genderAsSelectListItem = new SelectListItem();

                genderAsSelectListItem.Text = gender.gndr_descn;
                genderAsSelectListItem.Value = gender.gndr_id.ToString();

                gendersAsSelectListItems.Add(genderAsSelectListItem);
            }

            return gendersAsSelectListItems;
        }

        public List<SelectListItem> RefugeeStatusAsSelectListItems()
        {
            List<SelectListItem> refugeeStatusesAsSelectListItems = new List<SelectListItem>();

            var repo = new HealthInformationProgram.Data.Repositories.LookupBeneficiaryTypeRepository();
            List<lkup_bnfcry> allRefugeeStatus = repo.GetAll();

            foreach (lkup_bnfcry refugeeStatus in allRefugeeStatus)
            {
                SelectListItem refugeeStausAsSelectListItem = new SelectListItem();

                refugeeStausAsSelectListItem.Text = refugeeStatus.bnfcry;
                refugeeStausAsSelectListItem.Value = refugeeStatus.bnfcry_id.ToString();

                refugeeStatusesAsSelectListItems.Add(refugeeStausAsSelectListItem);
            }

            return refugeeStatusesAsSelectListItems;
        }

        public List<SelectListItem> NewOrRevisitStatusAsSelectListItems()
        {
            List<SelectListItem> newOrRevisitStatusAsSelectListItems = new List<SelectListItem>();

            RevisitData revisitData = new RevisitData();
            List<RevisitModel> allRevisitData = revisitData.GetAllRevisits();

            foreach (RevisitModel revisit in allRevisitData)
            {
                SelectListItem revistAsSelectListItem = new SelectListItem();

                revistAsSelectListItem.Text = revisit.Description;
                revistAsSelectListItem.Value = revisit.RevisitId;

                newOrRevisitStatusAsSelectListItems.Add(revistAsSelectListItem);
            }

            return newOrRevisitStatusAsSelectListItems;
        }

        public List<SelectListItem> SettlementandHealthCentresAsSelectListItems()
        {
            List<SelectListItem> settlementandHealthCentresAsSelectListItemsAsSelectListItems = new List<SelectListItem>();

            FacilityData facilityData = new FacilityData();
            List<FacilityModel> allFacilities = facilityData.GetFacilityList();

            foreach (FacilityModel facility in allFacilities)
            {
                SelectListItem facilityAsSelectListItem = new SelectListItem();

                facilityAsSelectListItem.Text = facility.HealthCareFacility;
                facilityAsSelectListItem.Value = facility.FacilityId;

                settlementandHealthCentresAsSelectListItemsAsSelectListItems.Add(facilityAsSelectListItem);
            }

            return settlementandHealthCentresAsSelectListItemsAsSelectListItems;
        }

        public List<SelectListItem> SupplementalDiagnosisCategoryNamesAsSelectListItems()
        {
            List<SelectListItem> supplementalDiagnosisCategoryNamesAsSelectListItems = new List<SelectListItem>();

            DiagnosisData diagnosisData = new DiagnosisData();
            List<SupplementalDiagnosisCategoryModel> allSupplementalDiagnosisCategoryNames = diagnosisData.GetAllSupplementalCategories();

            foreach (SupplementalDiagnosisCategoryModel supplementalDiagnosisCategory in allSupplementalDiagnosisCategoryNames)
            {
                SelectListItem supplementalDiagnosisCategoryAsSelectListItem = new SelectListItem();

                supplementalDiagnosisCategoryAsSelectListItem.Text = supplementalDiagnosisCategory.SupplementalDiagnosisCategoryType;
                supplementalDiagnosisCategoryAsSelectListItem.Value = supplementalDiagnosisCategory.SupplementalDiagnosisCategoryId;

                supplementalDiagnosisCategoryNamesAsSelectListItems.Add(supplementalDiagnosisCategoryAsSelectListItem);
            }

            return supplementalDiagnosisCategoryNamesAsSelectListItems;
        }
    }
}