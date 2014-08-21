using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eqRotDoc.dx;

namespace cfiXML_API
{
    class cfiXML_Enums
    {
        /// <summary>
        /// Enum correspondente: eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues
        /// 
        /// PumpDesignStandard
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:pumpDesignStandard
        /// 
        /// 
        /// Todos estas funções, caso elas não encontrem o correspondente no enum elas retornam .eOther.
        ///     Caso o enum não possua o valor .eOther a função retorna .ecustom.
        /// </summary>
        /// <param name="pumpDesignStandard"></param>
        /// <returns></returns>
        public static eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues getPumpDesignStandard(String pumpDesignStandard)
        {
            if (pumpDesignStandard == null || pumpDesignStandard.Equals(String.Empty))
            {
                return eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eNil;
            }

            eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.Invalid;

            if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eAPI_610.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eAPI_610;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eASME_B73_1.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eASME_B73_1;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eASME_B73_2.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eASME_B73_2;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eISO_13709.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eISO_13709;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eNFPA_20.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eNFPA_20;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP003H.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP003H;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP003S.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP003S;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP003V.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP003V;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP73H_97.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP73H_97;
            }
            else if (pumpDesignStandard.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP73V_97.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ePIP_RESP73V_97;
            }
            else
            {
                pDesignStandard = eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eOther;
            }

            return pDesignStandard;
        }

        /// <summary>
        /// Enum correspondente: EDocumentTypeType.EnumValues
        /// 
        /// centrifugalPumpDataSheet/dataSheetHeader/dataSheetType
        /// 
        /// </summary>
        /// <param name="dataSheetType"></param>
        /// <returns></returns>
        public static EDocumentTypeType.EnumValues getDataSheetType(String dataSheetType)
        {
            if (dataSheetType == null || dataSheetType.Equals(String.Empty))
            {
                return EDocumentTypeType.EnumValues.eNil;
            }

            EDocumentTypeType.EnumValues dSheetType = EDocumentTypeType.EnumValues.Invalid;

            if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eAs_built.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eAs_built;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eBudget_inquiry.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eBudget_inquiry;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eBudget_quotation.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eBudget_quotation;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eCare__install_and_spares.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eCare__install_and_spares;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eEstimate.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eEstimate;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eFabricator_order.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eFabricator_order;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eInquiry.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eInquiry;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eManufacturer_order.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eManufacturer_order;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eManufacturer_specification.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eManufacturer_specification;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eOther.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eOther;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.ePiping_and_Instrumentation_Diagram__PID_.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.ePiping_and_Instrumentation_Diagram__PID_;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.ePressure_Temperature_curve.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.ePressure_Temperature_curve;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eProcess_Flow_Diagram__PFD_.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eProcess_Flow_Diagram__PFD_;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eProcess_requirement.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eProcess_requirement;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eProposal.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eProposal;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.ePurchase_Order__P_O_.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.ePurchase_Order__P_O_;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eQuotation.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eQuotation;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eReference_drawing.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eReference_drawing;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eReference_specification.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eReference_specification;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eRequest_For_Quotation__RFQ_.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eRequest_For_Quotation__RFQ_;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eRequisition.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eRequisition;
            }
            else if (dataSheetType.Equals(Utils.processEnumValue(EDocumentTypeType.EnumValues.eSupply_order.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                dSheetType = EDocumentTypeType.EnumValues.eSupply_order;
            }
            else
            {
                dSheetType = EDocumentTypeType.EnumValues.eOther;
            }

            return dSheetType;
        }

        /// <summary>
        /// Enum correspondente: eqRotDoc.obj.ETransactionTypeType.EnumValues
        /// 
        /// Se o String é igual a algum valor do enum eqRotDoc.obj.ETransactionTypeType.EnumValues, ele retorna o enum correspondente. Caso contrario, de acordo com
        /// o padrão cfiXML, ele retorna eqRotDoc.obj.ETransactionTypeType.EnumValues.ecustom.
        /// </summary>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public static eqRotDoc.obj.ETransactionTypeType.EnumValues getTransactionType(String transactionType)
        {
            if (transactionType == null || transactionType.Equals(String.Empty))
            {
                return eqRotDoc.obj.ETransactionTypeType.EnumValues.eNil;
            }

            eqRotDoc.obj.ETransactionTypeType.EnumValues tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.Invalid;

            if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eApproved.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eApproved;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eArchived.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eArchived;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eChecked.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eChecked;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eCreated.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eCreated;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eDeleted.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eDeleted;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eIssued.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eIssued;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eModified.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eModified;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eModified_copy.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eModified_copy;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eNew_revision.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eNew_revision;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.eOwnership_changed.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.eOwnership_changed;
            }
            else if (transactionType.Equals(Utils.processEnumValue(eqRotDoc.obj.ETransactionTypeType.EnumValues.ePublished.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.ePublished;
            }
            else
            {
                tranType = eqRotDoc.obj.ETransactionTypeType.EnumValues.ecustom;
            }

            return tranType;
        }

        /// <summary>
        /// Enum correspondente: eqRotDoc.site.EConfigurationTypeType.EnumValues
        /// </summary>
        /// <param name="operatingConfigurationType"></param>
        /// <returns></returns>
        public static eqRotDoc.site.EConfigurationTypeType.EnumValues getOperatingConfigurationType(String operatingConfigurationType)
        {
            if (operatingConfigurationType == null || operatingConfigurationType.Equals(String.Empty))
            {
                return eqRotDoc.site.EConfigurationTypeType.EnumValues.eNil;
            }

            if (operatingConfigurationType.Equals(Utils.processEnumValue(eqRotDoc.site.EConfigurationTypeType.EnumValues.eParallel.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                return eqRotDoc.site.EConfigurationTypeType.EnumValues.eParallel;
            }
            
            if (operatingConfigurationType.Equals(Utils.processEnumValue(eqRotDoc.site.EConfigurationTypeType.EnumValues.eSeries.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                return eqRotDoc.site.EConfigurationTypeType.EnumValues.eSeries;
            }
            else if (operatingConfigurationType.Equals(Utils.processEnumValue(eqRotDoc.site.EConfigurationTypeType.EnumValues.eStandalone.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                return eqRotDoc.site.EConfigurationTypeType.EnumValues.eStandalone;
            }
            else if (operatingConfigurationType.Equals(Utils.processEnumValue(eqRotDoc.site.EConfigurationTypeType.EnumValues.eUnspecified.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                return eqRotDoc.site.EConfigurationTypeType.EnumValues.eUnspecified;
            }

            return eqRotDoc.site.EConfigurationTypeType.EnumValues.ecustom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseplateDrainig"></param>
        /// <returns></returns>
        public static eqRotDoc.eqRot.EBaseplateDrainType.EnumValues getBaseplateDrainig(String baseplateDrainig)
        {


            if (String.IsNullOrEmpty(baseplateDrainig))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eNil;
            else if (baseplateDrainig.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.ecustom.ToString()), StringComparison.InvariantCultureIgnoreCase))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.ecustom;
            else if (baseplateDrainig.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_connection.ToString()), StringComparison.InvariantCultureIgnoreCase))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_connection;
            else if (baseplateDrainig.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_pan___full.ToString()), StringComparison.InvariantCultureIgnoreCase))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_pan___full;
            else if (baseplateDrainig.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_pan___partial.ToString()), StringComparison.InvariantCultureIgnoreCase))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_pan___partial;
            else if (baseplateDrainig.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_rim___full.ToString()), StringComparison.InvariantCultureIgnoreCase))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eDrain_pan___full;
            else if (baseplateDrainig.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eOpen_drain.ToString()), StringComparison.InvariantCultureIgnoreCase))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eOpen_drain;
            else if (baseplateDrainig.Equals(Utils.processEnumValue(eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eUnspecified.ToString()), StringComparison.InvariantCultureIgnoreCase))
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eUnspecified;
            else
                return eqRotDoc.eqRot.EBaseplateDrainType.EnumValues.eOther;
        }
    }
}
