using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using eqRotDoc.dx;
using eqRotDoc;
using eqRotDoc.ctx;

namespace cfiXML_API
{
    /// <summary>
    /// Classe que contém os métodos públicos que geram/lêem do cfiXML (i.e. os métodos que geram os nós que possuem um Global Number HI
    /// </summary>
    public partial class cfiXML_Handler
    {

        #region Page 1
        /// <summary>
        /// Global number: 241
        /// API name: Comments Page 1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:remark
        /// </summary>
        /// <param name="DataSheetRemark"></param>
        public void DataSheetRemark_Writer(String dataSheetRemark)
        {
            if (String.IsNullOrEmpty(dataSheetRemark))
            {
                return;
            }
            CentrifugalPumpDataSheet cenPumpDataSheet = centrifugalPumpDataSheet2();

            if (!cenPumpDataSheet.remark.Exists)
            {
                cenPumpDataSheet.remark.Append();
            }

            cenPumpDataSheet.remark.First.Value = dataSheetRemark;
        }

        /// <summary>
        /// Global number: 241
        /// API name: Comments Page 1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:remark
        /// </summary>
        /// <returns></returns>
        public String DataSheetRemark_Reader()
        {
            CentrifugalPumpDataSheet cenPumpDataSheet = centrifugalPumpDataSheet2();

            if (!cenPumpDataSheet.remark.Exists)
            {
                return String.Empty;
            }

            return cenPumpDataSheet.remark.First.Value;
        }

        /// <summary>
        /// Global number: 232
        /// API name: GEAR-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Gears"]/dx:id
        /// </summary>
        /// <param name="GearDataSheetID"></param>
        public void GearDataSheetID_Writer(String gearDataSheetID)
        {
            if (String.IsNullOrEmpty(gearDataSheetID))
                return;
            AssociatedDataSheet aDataSheet = AssociatedDataSheet_documentEquipmentType_Gear();

            if (!aDataSheet.id.Exists)
            {
                aDataSheet.id.Append();
            }

            aDataSheet.id.First.Value = gearDataSheetID;
        }

        /// <summary>
        /// Global number: 232
        /// API name: GEAR-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Gears"]/dx:id
        /// </summary>
        /// <returns></returns>
        public String GearDataSheetID_Reader()
        {
            AssociatedDataSheet aDataSheet = AssociatedDataSheet_documentEquipmentType_Gear();

            if (!aDataSheet.id.Exists)
            {
                return String.Empty;
            }

            return aDataSheet.id.First.Value;
        }

        /// <summary>
        /// Global number: 157
        /// API name: MOTOR-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Driver"]/dx:id
        /// </summary>
        /// <param name="MotorDataSheetID"></param>
        public void MotorDataSheetID_Writer(String motorDataSheetID)
        {
            if (String.IsNullOrEmpty(motorDataSheetID))
                return;
            AssociatedDataSheet aDataSheet = AssociatedDataSheet_documentEquipmentType_Driver();

            if (!aDataSheet.id.Exists)
            {
                aDataSheet.id.Append();
            }

            aDataSheet.id.First.Value = motorDataSheetID;
        }

        /// <summary>
        /// Global number: 157
        /// API name: MOTOR-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Driver"]/dx:id
        /// </summary>
        /// <returns></returns>
        public String MotorDataSheetID_Reader()
        {
            AssociatedDataSheet aDataSheet = AssociatedDataSheet_documentEquipmentType_Driver();

            if (!aDataSheet.id.Exists)
            {
                return String.Empty;
            }

            return aDataSheet.id.First.Value;
        }

        /// <summary>
        /// Global number: 409
        /// API name: Client-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project/ctx:organizationContext[ctx:organizationRole="Owner"]/ctx:organization/objb:name
        /// </summary>
        /// <param name="OwnerName"></param>
        public void OwnerName_Writer(String ownerName)
        {
            if (String.IsNullOrEmpty(ownerName))
                return;
            OrganizationContext context = OrganizationContext_Owner();

            if (!context.organization2.Exists)
            {// nao existe organization                
                context.organization2.Append().name.Append().Value = ownerName;
            }

            else if (!context.organization2.First.name.Exists)
            {// existe organization e nao existe o campo nome
                context.organization2.First.name.Append().Value = ownerName;
            }
            else
            {//existe organization e ja existe o campo nome
                context.organization2.First.name.First.Value = ownerName;
            }
        }

        /// <summary>
        /// Global number: 409
        /// API name: Client-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project/ctx:organizationContext[ctx:organizationRole="Owner"]/ctx:organization/objb:name
        /// </summary>
        /// <returns></returns>
        public String OwnerName_Reader()
        {
            OrganizationContext context = OrganizationContext_Owner();

            if (!context.organization2.Exists)
            {// nao existe organization        
                return String.Empty;
            }

            else if (!context.organization2.First.name.Exists)
            {// existe organization e nao existe o campo nome
                return String.Empty;
            }
            else
            {//existe organization e ja existe o campo nome
                return context.organization2.First.name.First.Value;
            }
        }

        /// <summary>
        /// Global number: 280
        /// API name: JOB NUMBER-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project/proj:id
        /// </summary>
        /// <param name="ProjectID"></param>
        public void ProjectID_Writer(String projectID)
        {
            if (String.IsNullOrEmpty(projectID))
                return;
            eqRotDoc.proj.Project proj = project();

            if (!proj.id.Exists)
            {
                proj.id.Append();
            }

            proj.id.First.Value = projectID;
        }

        /// <summary>
        /// Global number: 280
        /// API name: JOB NUMBER-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project/proj:id
        /// </summary>
        /// <returns></returns>
        public String ProjectID_Reader()
        {
            eqRotDoc.proj.Project proj = project();

            if (!proj.id.Exists)
            {
                return String.Empty;
            }

            return proj.id.First.Value;
        }

        /// <summary>
        /// Global number: 446
        /// API name: Project Title-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project/objb:name
        /// </summary>
        /// <param name="ProjectName"></param>
        public void ProjectName_Writer(String projectName)
        {
            if (String.IsNullOrEmpty(projectName))
                return;
            eqRotDoc.proj.Project proj = project();

            if (!proj.name.Exists)
            {
                proj.name.Append();
            }

            proj.name.First.Value = projectName;
        }

        /// <summary>
        /// Global number: 446
        /// API name: Project Title-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project/objb:name
        /// </summary>
        /// <returns></returns>
        public String ProjectName_Reader()
        {
            eqRotDoc.proj.Project proj = project();

            if (!proj.name.Exists)
            {
                return String.Empty;
            }

            return proj.name.First.Value;
        }

        /// <summary>
        /// Global number: 279
        /// API name: Equipment Number-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:tag[@taggedItem="Assembly"]
        /// </summary>
        /// <param name="PumpAssemblyTagID"></param>
        public void PumpAssemblyTagID_Writer(String pumpAssemblyTagID)
        {
            if (String.IsNullOrEmpty(pumpAssemblyTagID))
                return;
            eqRotDoc.eq.idType cenPumpID = centrifugalPump_ID();

            cenPumpID.tag.Append().taggedItem.EnumerationValue = eqRotDoc.eq.ETaggedItem.EnumValues.eAssembly;
            cenPumpID.tag.First.Value = pumpAssemblyTagID;
        }

        /// <summary>
        /// Global number: 279
        /// API name: Equipment Number-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:tag[@taggedItem="Assembly"]
        /// </summary>
        /// <returns></returns>
        public String PumpAssemblyTagID_Reader()
        {
            eqRotDoc.eq.idType cenPumpID = centrifugalPump_ID();

            if (!cenPumpID.tag.Exists)
                return String.Empty;

            //cenPumpID.tag.Append().taggedItem.EnumerationValue = eqRotDoc.eq.ETaggedItem.EnumValues.eAssembly;

            return cenPumpID.tag.First.Value;
        }

        /// <summary>
        /// Global number: 449
        /// API name: PUMP-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:documentID/dx:id
        /// </summary>
        /// <param name="PumpDataSheetID"></param>
        public void PumpDataSheetID_Writer(String pumpDataSheetID)
        {
            if (String.IsNullOrEmpty(pumpDataSheetID))
                return;
            documentIDType docID = documentID();

            if (!docID.id.Exists)
            {
                docID.id.Append();
            }

            docID.id.First.Value = pumpDataSheetID;
        }

        /// <summary>
        /// Global number: 449
        /// API name: PUMP-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:documentID/dx:id
        /// </summary>
        /// <returns></returns>
        public String PumpDataSheetID_Reader()
        {
            documentIDType docID = documentID();

            if (!docID.id.Exists)
            {
                return String.Empty;
            }

            return docID.id.First.Value;
        }

        /// <summary>
        /// Global number: 522
        /// API name: Serial Number-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:serialNumber
        /// </summary>
        /// <param name="PumpSerialNumber"></param>
        public void PumpSerialNumber_Writer(String pumpSerialNumber)
        {
            if (String.IsNullOrEmpty(pumpSerialNumber))
                return;
            eqRotDoc.eq.idType cenPumpID = centrifugalPump_ID();

            if (!cenPumpID.serialNumber.Exists)
            {
                cenPumpID.serialNumber.Append();
            }

            cenPumpID.serialNumber.First.Value = pumpSerialNumber;
        }

        /// <summary>
        /// Global number: 522
        /// API name: Serial Number-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:serialNumber
        /// </summary>
        /// <returns></returns>
        public String PumpSerialNumber_Reader()
        {
            eqRotDoc.eq.idType cenPumpID = centrifugalPump_ID();

            if (!cenPumpID.serialNumber.Exists)
            {
                return String.Empty;
            }

            return cenPumpID.serialNumber.First.Value;
        }

        /// <summary>
        /// Global number: 15
        /// API name: APPLICABLE OVERLAY STANDARD(S)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:remark
        /// </summary>
        /// <param name="PumpStandardRemark"></param>
        public void PumpStandardRemark_Writer(String pumpStandardRemark)
        {
            if (String.IsNullOrEmpty(pumpStandardRemark))
                return;
            eqRotDoc.eqRot.applicableStandardType4 appStandard = applicableStandard();

            if (!appStandard.remark.Exists)
            {
                appStandard.remark.Append();
            }

            appStandard.remark.First.Value = pumpStandardRemark;
        }

        /// <summary>
        /// Global number: 15
        /// API name: APPLICABLE OVERLAY STANDARD(S)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:remark
        /// </summary>
        /// <returns></returns>
        public String PumpStandardRemark_Reader()
        {
            eqRotDoc.eqRot.applicableStandardType4 appStandard = applicableStandard();

            if (!appStandard.remark.Exists)
            {
                return String.Empty;
            }

            return appStandard.remark.First.Value;
        }

        /// <summary>
        /// Global number: 469
        /// API name: PURCH ORDER NO.-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:alternativeDocumentID[dx:documentType="Purchase Order (P/O)"]/dx:id
        /// </summary>
        /// <param name="PurchaseOrderID"></param>
        public void PurchaseOrderID_Writer(String purchaseOrderID)
        {
            if (String.IsNullOrEmpty(purchaseOrderID))
                return;
            AlternativeDocumentID altID = AlternativeDocumentID_PurchaseOrder();

            if (!altID.id.Exists)
            {
                altID.id.Append();
            }

            altID.id.First.Value = purchaseOrderID;
        }

        /// <summary>
        /// Global number: 469
        /// API name: PURCH ORDER NO.-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:alternativeDocumentID[dx:documentType="Purchase Order (P/O)"]/dx:id
        /// </summary>
        /// <returns></returns>
        public String PurchaseOrderID_Reader()
        {
            AlternativeDocumentID altID = AlternativeDocumentID_PurchaseOrder();

            if (!altID.id.Exists)
            {
                return String.Empty;
            }

            return altID.id.First.Value;
        }

        /// <summary>
        /// Global number: 488
        /// API name: REQ NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:alternativeDocumentID[dx:documentType="Requisition"]/dx:id
        /// </summary>
        /// <param name="RequistionID"></param>
        public void RequisitionID_Writer(String requisitionID)
        {
            if (String.IsNullOrEmpty(requisitionID))
                return;
            AlternativeDocumentID altID = AlternativeDocumentID_Requisition();

            if (!altID.id.Exists)
            {
                altID.id.Append();
            }

            altID.id.First.Value = requisitionID;
        }

        /// <summary>
        /// Global number: 488
        /// API name: REQ NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:alternativeDocumentID[dx:documentType="Requisition"]/dx:id
        /// </summary>
        /// <returns></returns>
        public String RequisitionID_Reader()
        {
            AlternativeDocumentID altID = AlternativeDocumentID_Requisition();

            if (!altID.id.Exists)
            {
                return String.Empty;
            }

            return altID.id.First.Value;
        }

        /// <summary>
        /// Global number: 502
        /// API name: RevisionNumber1
        /// /eqRotDoc:centrifugalPumpDataSheet/@revision
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="revisionID"></param>
        public void RevisionID_Writer(String revisionID)
        {
            if (revisionID == null || revisionID.Equals(String.Empty))
                return;

            centrifugalPumpDataSheet2().revision.Value = revisionID;
        }

        /// <summary>
        /// Global number: 502
        /// API name: RevisionNumber1
        /// /eqRotDoc:centrifugalPumpDataSheet/@revision
        /// Algumas vezes os xmls não vão conter o atributo revision no nó raiz.
        /// Se este get (centrifugalPumpDataSheet2().revision.Value) não retornar nada, é porque o documento só tem uma revisão. 
        /// Então é preciso procurar no nó revision dentro dos transactions e pegar o valor dentro deste nó. Ele será o revision.
        /// </summary>
        /// <returns></returns>
        public String RevisionID_Reader()
        {
            if (!centrifugalPumpDataSheet2().revision.Exists())
            {
                return getRevisionOfAnyTransactionNode();
            }
            return centrifugalPumpDataSheet2().revision.Value;
        }

        /// <summary>
        /// Global number: 523
        /// API name: SERVICE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/etl:serviceCategory/etl:serviceDescription
        /// </summary>
        /// <param name="ServiceDescription"></param>
        public void ServiceDescription_Writer(String serviceDescription)
        {
            if (String.IsNullOrEmpty(serviceDescription))
                return;
            eqRotDoc.etl.ServiceCategory servDesc = serviceCategory();

            if (!servDesc.serviceDescription.Exists)
            {
                servDesc.serviceDescription.Append();
            }

            servDesc.serviceDescription.First.Value = serviceDescription;
        }

        /// <summary>
        /// Global number: 523
        /// API name: SERVICE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/etl:serviceCategory/etl:serviceDescription
        /// </summary>
        /// <returns></returns>
        public String ServiceDescription_Reader()
        {
            eqRotDoc.etl.ServiceCategory servDesc = serviceCategory();

            if (!servDesc.serviceDescription.Exists)
            {
                return String.Empty;
            }

            return servDesc.serviceDescription.First.Value;
        }

        /// <summary>
        /// Global number: 552
        /// API name: SPEC NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:specID
        /// </summary>
        /// <param name="SpecID"></param>
        public void SpecID_Writer(String specID)
        {
            if (String.IsNullOrEmpty(specID))
                return;
            eqRotDoc.eq.idType cenPumpID = centrifugalPump_ID();

            if (!cenPumpID.specID.Exists)
            {
                cenPumpID.specID.Append();
            }

            cenPumpID.specID.First.Value = specID;
        }

        /// <summary>
        /// Global number: 552
        /// API name: SPEC NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:specID
        /// </summary>
        /// <returns></returns>
        public String SpecID_Reader()
        {
            eqRotDoc.eq.idType cenPumpID = centrifugalPump_ID();

            if (!cenPumpID.specID.Exists)
            {
                return String.Empty;
            }

            return cenPumpID.specID.First.Value;
        }

        /// <summary>
        /// Global number 623
        /// API name: RevisionDate1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[Qualquer revision menor ou igual que a obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType=Qualquer transaction type]/obj:dateTime
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="transactionDateTime"></param>
        public void TransactionDateTime_Writer(DateTime transactionDateTime, String revisionID, String transactionType)
        {
            if (transactionDateTime == null || transactionDateTime.Equals(String.Empty)
                || revisionID == null || revisionID.Equals(String.Empty)
                || transactionType == null || transactionType.Equals(String.Empty))
                return;

            eqRotDoc.obj.Transaction tran = getTransactionNode(revisionID, transactionType);

            if (!tran.dateTime.Exists)
            {
                tran.dateTime.Append();
            }

            Altova.Types.DateTime dateTimeAltova = new Altova.Types.DateTime();
            dateTimeAltova.Value = transactionDateTime;

            tran.dateTime.First.Value = dateTimeAltova;//
        }

        // Verificar
        /// <summary>
        /// Global number 623
        /// API name: RevisionDate1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Modified"]/obj:dateTime
        /// </summary>
        /// <param name="xml"></param>
        /// <returns>A data de modificação da última revisão.</returns>
        public DateTime TransactionDateTime_Reader(String revisionID, String transactionType)
        {
            eqRotDoc.obj.Transaction tran = getTransactionNode(revisionID, transactionType);

            if (!tran.dateTime.Exists)
            {
                return default(DateTime);
            }

            return tran.dateTime.First.Value.GetDateTime(true);
        }

        /// <summary>
        /// Global number: 50
        /// API name: RevisionBy1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Modified"]/ctx:person/ctx:shortID
        /// 
        /// Global number: 71
        /// API name: RevisionChecked1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Checked"]/ctx:person/ctx:shortID
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="transactionPersonCreatedOrModified"></param>
        public void TransactionPerson_Writer(String transactionPerson, String revisionID, String transactionType)
        {
            if (transactionType == null || transactionType.Equals(String.Empty))
                return;

            eqRotDoc.obj.Transaction tran = getTransactionNode(revisionID, transactionType);

            if (!tran.person.Exists)
            {
                // o elemento person só é criado com o elemento shortID e o shortID precisa de um valor
                tran.person.Append().shortID.Append();
            }

            tran.person.First.shortID.First.Value = transactionPerson;
        }

        /// <summary>
        /// <summary>
        /// Global number: 50
        /// API name: RevisionBy1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Modified"]/ctx:person/ctx:shortID
        /// 
        /// Global number: 71
        /// API name: RevisionChecked1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Checked"]/ctx:person/ctx:shortID
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="revisionID"></param>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public String TransactionPerson_Reader(String revisionID, String transactionType)
        {
            eqRotDoc.obj.Transaction tran = getTransactionNode(revisionID, transactionType);

            if (!tran.person.Exists)
            {
                // o elemento person só é criado com o elemento shortID e o shortID precisa de um valor
                return null;
            }

            return tran.person.First.shortID.First.Value;
        }

        /// <summary>
        /// Global number 483
        /// API name: RevisionDescription1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Modified"]/obj:remark
        /// Este no cfiXML é encarado como o comentário da revisão.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="transactionRemark"></param>
        public void TransactionRemark_Writer(String transactionRemark, String revisionID, String transactionType)
        {
            if (transactionRemark == null || transactionRemark.Equals(String.Empty))
                return;

            eqRotDoc.obj.Transaction tran = getTransactionNode(revisionID, transactionType);

            if (!tran.remark.Exists)
            {
                tran.remark.Append();
            }

            tran.remark.First.Value = transactionRemark;
        }

        /// <summary>
        /// Global number 483
        /// API name: RevisionDescription1
        /// /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Modified"]/obj:remark
        /// Este no cfiXML é encarado como o comentário da revisão.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="revisionID"></param>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public String TransactionRemark_Reader(String revisionID, String transactionType)
        {
            eqRotDoc.obj.Transaction tran = getTransactionNode(revisionID, transactionType);

            if (!tran.remark.Exists)
            {
                return null;
            }

            return tran.remark.First.Value;
        }

        /// <summary>
        /// Global number: 629
        /// API name: TURBINE-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Turbine"]/dx:id
        /// </summary>
        /// <param name="TurbineDataSheetID"></param>
        public void TurbineDataSheetID_Writer(String turbineDataSheetID)
        {
            if (String.IsNullOrEmpty(turbineDataSheetID))
                return;
            AssociatedDataSheet aDataSheet = AssociatedDataSheet_documentEquipmentType_Turbine();

            if (!aDataSheet.id.Exists)
            {
                aDataSheet.id.Append();
            }

            aDataSheet.id.First.Value = turbineDataSheetID;
        }

        /// <summary>
        /// Global number: 629
        /// API name: TURBINE-ITEM NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Turbine"]/dx:id
        /// </summary>
        /// <returns></returns>
        public String TurbineDataSheetID_Reader()
        {
            AssociatedDataSheet aDataSheet = AssociatedDataSheet_documentEquipmentType_Turbine();

            if (!aDataSheet.id.Exists)
            {
                return String.Empty;
            }

            return aDataSheet.id.First.Value;
        } 
        #endregion

        #region Page 2
        /// <summary>
        /// Global number: 476
        /// API name: RATED CURVE BEP FLOW (at rated impeller dia)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Rated"]/eqRot:operatingPerformance/eqRot:condition/eqRot:bestEfficiencyFlowVolume
        /// </summary>
        /// <param name="BestEffFlowForRatedImpeller"></param>
        public void BestEffFlowForRatedImpeller_Writer(String bestEffFlowForRatedImpeller)
        {
            if (String.IsNullOrEmpty(bestEffFlowForRatedImpeller))
                return;
            eqRotDoc.eqRot.conditionType5 condition = Condition_ImpellerWithPropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated);
            if (!condition.bestEfficiencyFlowVolume.Exists)
            {
                condition.bestEfficiencyFlowVolume.Append();
            }
            condition.bestEfficiencyFlowVolume.First.Value = bestEffFlowForRatedImpeller;
        }

        /// <summary>
        /// Global number: 476
        /// API name: RATED CURVE BEP FLOW (at rated impeller dia)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Rated"]/eqRot:operatingPerformance/eqRot:condition/eqRot:bestEfficiencyFlowVolume
        /// </summary>
        /// <returns></returns>
        public String BestEffFlowForRatedImpeller_Reader()
        {
            eqRotDoc.eqRot.conditionType5 condition = Condition_ImpellerWithPropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated);

            if (!condition.bestEfficiencyFlowVolume.Exists)
            {
                return null;
            }
            return condition.bestEfficiencyFlowVolume.First.Value;
        }

        /// <summary>
        /// Global number: 625
        /// API name: APPLICABLE TO:-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:dataSheetType
        /// </summary>
        /// <param name="DataSheetType"></param>
        public void DataSheetType_Writer(String dataSheetType)
        {
            if (String.IsNullOrEmpty(dataSheetType))
                return;
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            EDocumentTypeType.EnumValues dSheetType = cfiXML_Enums.getDataSheetType(dataSheetType);

            if (!dSheetHeader.dataSheetType.Exists)
            {
                // o elemento person só é criado com o elemento shortID e o shortID precisa de um valor
                dSheetHeader.dataSheetType.Append();
            }

            if (dSheetType.Equals(EDocumentTypeType.EnumValues.eOther) || dSheetType.Equals(EDocumentTypeType.EnumValues.ecustom))
            {
                dSheetHeader.dataSheetType.First.otherValue.Value = dataSheetType;
                dSheetHeader.dataSheetType.First.EnumerationValue = dSheetType;
            }
            else
            {
                dSheetHeader.dataSheetType.First.EnumerationValue = dSheetType;
            }
        }

        /// <summary>
        /// Global number: 625
        /// API name: APPLICABLE TO:-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:dataSheetType
        /// </summary>
        /// <returns></returns>
        public String DataSheetType_Reader()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (!dSheetHeader.dataSheetType.Exists)
            {
                return null;
            }

            EDocumentTypeType.EnumValues dSheetType = dSheetHeader.dataSheetType.First.EnumerationValue;

            if (dSheetType.Equals(EDocumentTypeType.EnumValues.eOther) || dSheetType.Equals(EDocumentTypeType.EnumValues.ecustom))
            {
                return dSheetHeader.dataSheetType.First.otherValue.Value;
            }

            return Utils.processEnumValue(dSheetType.ToString());
        }

        /// <summary>
        /// Global number: 133
        /// API name: DIFF. HEAD-Max.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"]/eqRot:head
        /// </summary>
        /// <param name="DiffHeadMax"></param>
        public void DiffHeadMax_Writer(String diffHeadMax)
        {
            if (String.IsNullOrEmpty(diffHeadMax))
                return;
            eqRotDoc.eqRot.conditionType3 condition = ConditionWithPropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum);

            if (!condition.head.Exists)
            {
                condition.head.Append();
            }
            condition.head.First.Value = diffHeadMax;
        }

        /// <summary>
        /// Global number: 133
        /// API name: DIFF. HEAD-Max.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"]/eqRot:head
        /// </summary>
        /// <returns></returns>
        public String DiffHeadMax_Reader()
        {
            eqRotDoc.eqRot.conditionType3 condition = ConditionWithPropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum);

            if (!condition.head.Exists)
            {
                return null;
            }
            return condition.head.First.Value;
        }

        /// <summary>
        /// Global number: 134
        /// API name: DIFF. HEAD-Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Minimum"]/eqRot:head
        /// </summary>
        /// <param name="DiffHeadMin"></param>
        public void DiffHeadMin_Writer(String diffHeadMin)
        {
            if (String.IsNullOrEmpty(diffHeadMin))
                return;
        }

        /// <summary>
        /// Global number: 134
        /// API name: DIFF. HEAD-Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Minimum"]/eqRot:head
        /// </summary>
        /// <returns></returns>
        public String DiffHeadMin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 135
        /// API name: DIFF. HEAD-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Normal"]/eqRot:head
        /// </summary>
        /// <param name="DiffHeadNormal"></param>
        public void DiffHeadNormal_Writer(String diffHeadNormal)
        {
            if (String.IsNullOrEmpty(diffHeadNormal))
                return;
        }

        /// <summary>
        /// Global number: 135
        /// API name: DIFF. HEAD-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Normal"]/eqRot:head
        /// </summary>
        /// <returns></returns>
        public String DiffHeadNormal_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 139
        /// API name: Differential Head-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Rated"]/eqRot:head[@valueSourceType="Required"]
        /// </summary>
        /// <param name="DiffHeadRatedRequired"></param>
        public void DiffHeadRatedRequired_Writer(String diffHeadRatedRequired)
        {
            if (String.IsNullOrEmpty(diffHeadRatedRequired))
                return;
        }

        /// <summary>
        /// Global number: 139
        /// API name: Differential Head-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Rated"]/eqRot:head[@valueSourceType="Required"]
        /// </summary>
        /// <returns></returns>
        public String DiffHeadRatedRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 148
        /// API name: DISCHARGE PRESSURE-Max.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:p
        /// </summary>
        /// <param name="DischargePMax"></param>
        public void DischargePMax_Writer(String dischargePMax)
        {
            if (String.IsNullOrEmpty(dischargePMax))
                return;
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eOutlet);

            if (!prop.p.Exists)
            {
                prop.p.Append();
            }

            prop.p.First.Value = dischargePMax;
        }

        /// <summary>
        /// Global number: 148
        /// API name: DISCHARGE PRESSURE-Max.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:p
        /// </summary>
        /// <returns></returns>
        public String DischargePMax_Reader()
        {
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eOutlet);

            if (!prop.p.Exists)
            {
                return null;
            }

            return prop.p.First.Value;
        }

        /// <summary>
        /// Global number: 149
        /// API name: DISCHARGE PRESSURE -Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:p
        /// </summary>
        /// <param name="DischargePMin"></param>
        public void DischargePMin_Writer(String dischargePMin)
        {
            if (String.IsNullOrEmpty(dischargePMin))
                return;
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eOutlet);
            if (!prop.p.Exists)
            {
                prop.p.Append();
            }
            prop.p.First.Value = dischargePMin;
        }

        /// <summary>
        /// Global number: 149
        /// API name: DISCHARGE PRESSURE -Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:p
        /// </summary>
        /// <returns></returns>
        public String DischargePMin_Reader()
        {
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eOutlet);
            if (!prop.p.Exists)
            {
                return null;
            }
            return prop.p.First.Value;
        }

        /// <summary>
        /// Global number: 150
        /// API name: DISCHARGE PRESSURE -NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:p
        /// </summary>
        /// <param name="DischargePNormal"></param>
        public void DischargePNormal_Writer(String dischargePNormal)
        {
            if (String.IsNullOrEmpty(dischargePNormal))
                return;
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eOutlet);

            if (!prop.p.Exists)
            {
                prop.p.Append();
            }

            prop.p.First.Value = dischargePNormal;
        }

        /// <summary>
        /// Global number: 150
        /// API name: DISCHARGE PRESSURE -NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:p
        /// </summary>
        /// <returns></returns>
        public String DischargePNormal_Reader()
        {
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eOutlet);

            if (!prop.p.Exists)
            {
                return null;
            }

            return prop.p.First.Value;
        }

        /// <summary>
        /// Global number: 147
        /// API name: DischargePressure-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Flowrate, Rated"]/mtrl:p
        /// </summary>
        /// <param name="DischargePRated"></param>
        public void DischargePRated_Writer(String dischargePRated)
        {
            if (String.IsNullOrEmpty(dischargePRated))
                return;
        }

        /// <summary>
        /// Global number: 147
        /// API name: DischargePressure-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Flowrate, Rated"]/mtrl:p
        /// </summary>
        /// <returns></returns>
        public String DischargePRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 163
        /// API name: MANUFACTURER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:id/ctx:manufacturerCompany/objb:name
        /// </summary>
        /// <param name="DriverManufacturer"></param>
        public void DriverManufacturer_Writer(String driverManufacturer)
        {
            if (String.IsNullOrEmpty(driverManufacturer))
                return;
        }

        /// <summary>
        /// Global number: 163
        /// API name: MANUFACTURER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:id/ctx:manufacturerCompany/objb:name
        /// </summary>
        /// <returns></returns>
        public String DriverManufacturer_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 356
        /// API name: FRAME OR MODEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:id/eq:model
        /// </summary>
        /// <param name="DriverModel"></param>
        public void DriverModel_Writer(String driverModel)
        {
            if (String.IsNullOrEmpty(driverModel))
                return;
        }

        /// <summary>
        /// Global number: 356
        /// API name: FRAME OR MODEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:id/eq:model
        /// </summary>
        /// <returns></returns>
        public String DriverModel_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 360
        /// API name: ORIENTATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:shape/eq:equipmentOrientation
        /// </summary>
        /// <param name="DriverOrientation"></param>
        public void DriverOrientation_Writer(String driverOrientation)
        {
            if (String.IsNullOrEmpty(driverOrientation))
                return;
        }

        /// <summary>
        /// Global number: 360
        /// API name: ORIENTATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:shape/eq:equipmentOrientation
        /// </summary>
        /// <returns></returns>
        public String DriverOrientation_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 166
        /// API name: NAMEPLATE POWER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eqRot:power[@usageContext="Conceptual specification"][@propertyType="Rated"]
        /// </summary>
        /// <param name="DriverPowerRated"></param>
        public void DriverPowerRated_Writer(String driverPowerRated)
        {
            if (String.IsNullOrEmpty(driverPowerRated))
                return;
        }

        /// <summary>
        /// Global number: 166
        /// API name: NAMEPLATE POWER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eqRot:power[@usageContext="Conceptual specification"][@propertyType="Rated"]
        /// </summary>
        /// <returns></returns>
        public String DriverPowerRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1918
        /// API name: Nominal RPM-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eqRot:rotationalSpeed[@usageContext="Conceptual specification"][@propertyType="Nominal"]
        /// </summary>
        /// <param name="DriverRotationalSpeedNominal"></param>
        public void DriverRotationalSpeedNominal_Writer(String driverRotationalSpeedNominal)
        {
            if (String.IsNullOrEmpty(driverRotationalSpeedNominal))
                return;
        }

        /// <summary>
        /// Global number: 1918
        /// API name: Nominal RPM-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eqRot:rotationalSpeed[@usageContext="Conceptual specification"][@propertyType="Nominal"]
        /// </summary>
        /// <returns></returns>
        public String DriverRotationalSpeedNominal_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 809
        /// API name: RATED LOAD RPM
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eqRot:rotationalSpeed[@usageContext="Conceptual specification"][@conditionType="Load - rated"]
        /// </summary>
        /// <param name="DriverRotationalSpeedRatedLoad"></param>
        public void DriverRotationalSpeedRatedLoad_Writer(String driverRotationalSpeedRatedLoad)
        {
            if (String.IsNullOrEmpty(driverRotationalSpeedRatedLoad))
                return;
        }

        /// <summary>
        /// Global number: 809
        /// API name: RATED LOAD RPM
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eqRot:rotationalSpeed[@usageContext="Conceptual specification"][@conditionType="Load - rated"]
        /// </summary>
        /// <returns></returns>
        public String DriverRotationalSpeedRatedLoad_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 175
        /// API name: Driver Type-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqRot:driverType
        /// </summary>
        /// <param name="DriverType"></param>
        public void DriverType_Writer(String driverType)
        {
            if (String.IsNullOrEmpty(driverType))
                return;
        }

        /// <summary>
        /// Global number: 175
        /// API name: Driver Type-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqRot:driverType
        /// </summary>
        /// <returns></returns>
        public String DriverType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 221
        /// API name: Flow-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Maximum"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Maximum"]
        /// </summary>
        /// <param name="FlowVolumeMax"></param>
        public void FlowVolumeMax_Writer(String flowVolumeMax)
        {
            if (String.IsNullOrEmpty(flowVolumeMax))
                return;
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                mFlow.actualVolumetricFlow.Append().referencePropertyID.Value = "Flowrate, Maximum";
            }

            mFlow.actualVolumetricFlow.First.Value = flowVolumeMax;
        }

        /// <summary>
        /// Global number: 221
        /// API name: Flow-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Maximum"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Maximum"]
        /// </summary>
        /// <returns></returns>
        public String FlowVolumeMax_Reader()
        {
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                return null;
            }

            return mFlow.actualVolumetricFlow.First.Value;
        }

        /// <summary>
        /// Global number: 222
        /// API name: Flow-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Minimum"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Minimum"]
        /// </summary>
        /// <param name="FlowVolumeMin"></param>
        public void FlowVolumeMin_Writer(String flowVolumeMin)
        {
            if (String.IsNullOrEmpty(flowVolumeMin))
                return;
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                mFlow.actualVolumetricFlow.Append().referencePropertyID.Value = "Flowrate, Minimum";
            }

            mFlow.actualVolumetricFlow.First.Value = flowVolumeMin;
        }

        /// <summary>
        /// Global number: 222
        /// API name: Flow-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Minimum"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Minimum"]
        /// </summary>
        /// <returns></returns>
        public String FlowVolumeMin_Reader()
        {
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                return null;
            }

            return mFlow.actualVolumetricFlow.First.Value;
        }

        /// <summary>
        /// Global number: 373
        /// API name: Flow-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Normal"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Normal"]
        /// </summary>
        /// <param name="FlowVolumeNormal"></param>
        public void FlowVolumeNormal_Writer(String flowVolumeNormal)
        {
            if (String.IsNullOrEmpty(flowVolumeNormal))
                return;
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                mFlow.actualVolumetricFlow.Append().referencePropertyID.Value = "Flowrate, Normal";
            }

            mFlow.actualVolumetricFlow.First.Value = flowVolumeNormal;
        }

        /// <summary>
        /// Global number: 373
        /// API name: Flow-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Normal"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Normal"]
        /// </summary>
        /// <returns></returns>
        public String FlowVolumeNormal_Reader()
        {
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                return null;
            }

            return mFlow.actualVolumetricFlow.First.Value;
        }

        /// <summary>
        /// Global number: 478
        /// API name: Flow-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Rated"][etl:valueSourceType="Required"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Rated"]
        /// </summary>
        /// <param name="FlowVolumeRatedRequired"></param>
        public void FlowVolumeRatedRequired_Writer(String flowVolumeRatedRequired)
        {
            if (String.IsNullOrEmpty(flowVolumeRatedRequired))
                return;
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eRequired, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                mFlow.actualVolumetricFlow.Append().referencePropertyID.Value = "Flowrate, Rated";
            }

            mFlow.actualVolumetricFlow.First.Value = flowVolumeRatedRequired;
        }

        /// <summary>
        /// Global number: 478
        /// API name: Flow-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="Rated"][etl:valueSourceType="Required"]/uo:actualVolumetricFlow[@referencePropertyID="Flowrate, Rated"]
        /// </summary>
        /// <returns></returns>
        public String FlowVolumeRatedRequired_Reader()
        {
            eqRotDoc.uo.MaterialFlow mFlow = materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated, eqRotDoc.etl.EValueSourceTypeType.EnumValues.eRequired, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mFlow.actualVolumetricFlow.Exists)
            {
                return null;
            }

            return mFlow.actualVolumetricFlow.First.Value;
        }

        /// <summary>
        /// Global number: 231
        /// API name: GEAR-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:gear/eqRot:isRequired
        /// </summary>
        /// <param name="GearRequired"></param>
        public void GearRequired_Writer(String gearRequired)
        {
            if (String.IsNullOrEmpty(gearRequired))
                return;
        }

        /// <summary>
        /// Global number: 231
        /// API name: GEAR-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:gear/eqRot:isRequired
        /// </summary>
        /// <returns></returns>
        public String GearRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 680
        /// API name: HYDRAULIC POWER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:hydraulicPower[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <param name="HydraulicPowerRated"></param>
        public void HydraulicPowerRated_Writer(String hydraulicPowerRated)
        {
            if (String.IsNullOrEmpty(hydraulicPowerRated))
                return;
        }

        /// <summary>
        /// Global number: 680
        /// API name: HYDRAULIC POWER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:hydraulicPower[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <returns></returns>
        public String HydraulicPowerRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 317
        /// API name: IMPELLER DIA -MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Maximum"]/eq:shape/etl:cylindricalShape/etl:diameter
        /// </summary>
        /// <param name="ImpellerDiameterMax"></param>
        public void ImpellerDiameterMax_Writer(String impellerDiameterMax)
        {
            if (String.IsNullOrEmpty(impellerDiameterMax))
                return;
        }

        /// <summary>
        /// Global number: 317
        /// API name: IMPELLER DIA -MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Maximum"]/eq:shape/etl:cylindricalShape/etl:diameter
        /// </summary>
        /// <returns></returns>
        public String ImpellerDiameterMax_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 344
        /// API name: IMPELLER DIA-MIN.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Minimum"]/eq:shape/etl:cylindricalShape/etl:diameter
        /// </summary>
        /// <param name="ImpellerDiameterMin"></param>
        public void ImpellerDiameterMin_Writer(String impellerDiameterMin)
        {
            if (String.IsNullOrEmpty(impellerDiameterMin))
                return;
        }

        /// <summary>
        /// Global number: 344
        /// API name: IMPELLER DIA-MIN.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Minimum"]/eq:shape/etl:cylindricalShape/etl:diameter
        /// </summary>
        /// <returns></returns>
        public String ImpellerDiameterMin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 479
        /// API name: IMPELLER DIA.    -RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Rated"]/eq:shape/etl:cylindricalShape/etl:diameter
        /// </summary>
        /// <param name="ImpellerDiameterRated"></param>
        public void ImpellerDiameterRated_Writer(String impellerDiameterRated)
        {
            if (String.IsNullOrEmpty(impellerDiameterRated))
                return;
        }

        /// <summary>
        /// Global number: 479
        /// API name: IMPELLER DIA.    -RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Rated"]/eq:shape/etl:cylindricalShape/etl:diameter
        /// </summary>
        /// <returns></returns>
        public String ImpellerDiameterRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 319
        /// API name: MAX POWER @ RATED IMPELLER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:brakePower[@usageContext="Operating performance"][@propertyType="Maximum"][@referenceProperty="Impeller Diameter, Rated"]
        /// </summary>
        /// <param name="MaxBrakePowerAtRatedImpeller"></param>
        public void MaxBrakePowerAtRatedImpeller_Writer(String maxBrakePowerAtRatedImpeller)
        {
            if (String.IsNullOrEmpty(maxBrakePowerAtRatedImpeller))
                return;
        }

        /// <summary>
        /// Global number: 319
        /// API name: MAX POWER @ RATED IMPELLER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:brakePower[@usageContext="Operating performance"][@propertyType="Maximum"][@referenceProperty="Impeller Diameter, Rated"]
        /// </summary>
        /// <returns></returns>
        public String MaxBrakePowerAtRatedImpeller_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 321
        /// API name: MAX. SOUND PRESS. LEVEL REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noiseNearItem[@valueSourceType="Allowable"][@propertyType="Maximum"]
        /// </summary>
        /// <param name="MaxSoundPAllowable"></param>
        public void MaxSoundPAllowable_Writer(String maxSoundPAllowable)
        {
            if (String.IsNullOrEmpty(maxSoundPAllowable))
                return;
        }

        /// <summary>
        /// Global number: 321
        /// API name: MAX. SOUND PRESS. LEVEL REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noiseNearItem[@valueSourceType="Allowable"][@propertyType="Maximum"]
        /// </summary>
        /// <returns></returns>
        public String MaxSoundPAllowable_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 214
        /// API name: EST MAX SOUND PRESS. LEVEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noiseNearItem[@valueSourceType="Estimated"][@propertyType="Maximum"]
        /// </summary>
        /// <param name="MaxSoundPEstimated"></param>
        public void MaxSoundPEstimated_Writer(String maxSoundPEstimated)
        {
            if (String.IsNullOrEmpty(maxSoundPEstimated))
                return;
        }

        /// <summary>
        /// Global number: 214
        /// API name: EST MAX SOUND PRESS. LEVEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noiseNearItem[@valueSourceType="Estimated"][@propertyType="Maximum"]
        /// </summary>
        /// <returns></returns>
        public String MaxSoundPEstimated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 759
        /// API name: MAX. SOUND POWER LEVEL REQ'D
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noisePowerNearItem[@valueSourceType="Allowable"][@propertyType="Maximum"]
        /// </summary>
        /// <param name="MaxSoundPowerAllowed"></param>
        public void MaxSoundPowerAllowed_Writer(String maxSoundPowerAllowed)
        {
            if (String.IsNullOrEmpty(maxSoundPowerAllowed))
                return;
        }

        /// <summary>
        /// Global number: 759
        /// API name: MAX. SOUND POWER LEVEL REQ'D
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noisePowerNearItem[@valueSourceType="Allowable"][@propertyType="Maximum"]
        /// </summary>
        /// <returns></returns>
        public String MaxSoundPowerAllowed_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 213
        /// API name: EST MAX SOUND POWER LEVEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noisePowerNearItem[@valueSourceType="Estimated"][@propertyType="Maximum"]
        /// </summary>
        /// <param name="MaxSoundPowerEstimated"></param>
        public void MaxSoundPowerEstimated_Writer(String maxSoundPowerEstimated)
        {
            if (String.IsNullOrEmpty(maxSoundPowerEstimated))
                return;
        }

        /// <summary>
        /// Global number: 213
        /// API name: EST MAX SOUND POWER LEVEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:noise/eq:noisePowerNearItem[@valueSourceType="Estimated"][@propertyType="Maximum"]
        /// </summary>
        /// <returns></returns>
        public String MaxSoundPowerEstimated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 208
        /// API name: LUBE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqElec:electricMotor/eq:bearingAssembly/eq:lubeSystem/eq:lubeSystemType
        /// </summary>
        /// <param name="MotorLubeSystemType"></param>
        public void MotorLubeSystemType_Writer(String motorLubeSystemType)
        {
            if (String.IsNullOrEmpty(motorLubeSystemType))
                return;
        }

        /// <summary>
        /// Global number: 208
        /// API name: LUBE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqElec:electricMotor/eq:bearingAssembly/eq:lubeSystem/eq:lubeSystemType
        /// </summary>
        /// <returns></returns>
        public String MotorLubeSystemType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 350
        /// API name: Motor Radial Bearing Number
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:bearingAssembly/eq:bearingDetail/eq:radialBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <param name="MotorRadialBearingNumber"></param>
        public void MotorRadialBearingNumber_Writer(String motorRadialBearingNumber)
        {
            if (String.IsNullOrEmpty(motorRadialBearingNumber))
                return;
        }

        /// <summary>
        /// Global number: 350
        /// API name: Motor Radial Bearing Number
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:bearingAssembly/eq:bearingDetail/eq:radialBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <returns></returns>
        public String MotorRadialBearingNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 352
        /// API name: Motor Thrust Bearing Number
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:bearingAssembly/eq:bearingDetail/eq:thrustBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <param name="MotorThrustBearingNumber"></param>
        public void MotorThrustBearingNumber_Writer(String motorThrustBearingNumber)
        {
            if (String.IsNullOrEmpty(motorThrustBearingNumber))
                return;
        }

        /// <summary>
        /// Global number: 352
        /// API name: Motor Thrust Bearing Number
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:bearingAssembly/eq:bearingDetail/eq:thrustBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <returns></returns>
        public String MotorThrustBearingNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 681
        /// API name: NPSHa Datum
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:npshaDatumLocation
        /// </summary>
        /// <param name="NPSHAvailableDatum"></param>
        public void NPSHAvailableDatum_Writer(String nPSHAvailableDatum)
        {
            if (String.IsNullOrEmpty(nPSHAvailableDatum))
                return;
        }

        /// <summary>
        /// Global number: 681
        /// API name: NPSHa Datum
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:npshaDatumLocation
        /// </summary>
        /// <returns></returns>
        public String NPSHAvailableDatum_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 381
        /// API name: NPSHA-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:npsh[@usageContext="Operating performance"][@valueSourceType="Available"][@referenceProperty="Flowrate, Rated"]
        /// </summary>
        /// <param name="NPSHAvailableRated"></param>
        public void NPSHAvailableRated_Writer(String nPSHAvailableRated)
        {
            if (String.IsNullOrEmpty(nPSHAvailableRated))
                return;
        }

        /// <summary>
        /// Global number: 381
        /// API name: NPSHA-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:npsh[@usageContext="Operating performance"][@valueSourceType="Available"][@referenceProperty="Flowrate, Rated"]
        /// </summary>
        /// <returns></returns>
        public String NPSHAvailableRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 418
        /// API name: PUMPS OPERATE IN-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/site:equipmentSet/site:equipmentConfiguration/site:configurationType
        /// </summary>
        /// <param name="OperatingConfiguration"></param>
        public void OperatingConfiguration_Writer(String operatingConfiguration)
        {
            if (String.IsNullOrEmpty(operatingConfiguration))
                return;
            eqRotDoc.site.EConfigurationTypeType.EnumValues value = cfiXML_Enums.getOperatingConfigurationType(operatingConfiguration);


            eqRotDoc.site.EquipmentConfiguration equiConf = equipmentConfiguration();

            if (!equiConf.configurationType.Exists)
            {
                equiConf.configurationType.Append();
            }

            if (value.Equals(eqRotDoc.site.EConfigurationTypeType.EnumValues.ecustom))
            {// Tem que criar o nó other ja que o valor que vou escrever no xml nao tem no enumeration.
                equiConf.configurationType.First.EnumerationValue = value;
                equiConf.configurationType.First.otherValue.Value = operatingConfiguration;
            }
            else
            {
                equiConf.configurationType.First.EnumerationValue = value;
            }
        }

        /// <summary>
        /// Global number: 418
        /// API name: PUMPS OPERATE IN-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/site:equipmentSet/site:equipmentConfiguration/site:configurationType
        /// </summary>
        /// <returns></returns>
        public String OperatingConfiguration_Reader()
        {
            eqRotDoc.site.EquipmentConfiguration equiConf = equipmentConfiguration();

            if (!equiConf.configurationType.Exists)
            {
                return null;
            }

            eqRotDoc.site.EConfigurationTypeType.EnumValues value = equiConf.configurationType.First.EnumerationValue;

            if (value.Equals(eqRotDoc.site.EConfigurationTypeType.EnumValues.ecustom))
            {
                return equiConf.configurationType.First.otherValue.Value;
            }

            return Utils.processEnumValue(value.ToString());
        }

        /// <summary>
        /// Global number: 557
        /// API name: IF INTERMITTENT (STARTS/DAY)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance[eq:operationType="Intermittent"]/eqRot:start/eqRot:startPerDay
        /// </summary>
        /// <param name="OperationStartPerDay"></param>
        public void OperationStartPerDay_Writer(String operationStartPerDay)
        {
            if (String.IsNullOrEmpty(operationStartPerDay))
                return;
        }

        /// <summary>
        /// Global number: 557
        /// API name: IF INTERMITTENT (STARTS/DAY)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance[eq:operationType="Intermittent"]/eqRot:start/eqRot:startPerDay
        /// </summary>
        /// <returns></returns>
        public String OperationStartPerDay_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 397
        /// API name: SERVICE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eq:operationType
        /// </summary>
        /// <param name="OperationType"></param>
        public void OperationType_Writer(String operationType)
        {
            if (String.IsNullOrEmpty(operationType))
                return;
        }

        /// <summary>
        /// Global number: 397
        /// API name: SERVICE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eq:operationType
        /// </summary>
        /// <returns></returns>
        public String OperationType_Reader()
        {
            return null;
        }
            
        /// <summary>
        /// Global number: 136
        /// API name: DIFFERENTIAL PRESSURE-Max.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Maximum"]
        /// </summary>
        /// <param name="PDifferenceMax"></param>
        public void PDifferenceMax_Writer(String pDifferenceMax)
        {
            if (String.IsNullOrEmpty(pDifferenceMax))
                return;
            PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eMaximum).Value = pDifferenceMax;
        }

        /// <summary>
        /// Global number: 136
        /// API name: DIFFERENTIAL PRESSURE-Max.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Maximum"]
        /// </summary>
        /// <returns></returns>
        public String PDifferenceMax_Reader()
        {
            return PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eMaximum).Value;
        }

        /// <summary>
        /// Global number: 137
        /// API name: DIFFERENTIAL PRESSURE-Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Minimum"]
        /// </summary>
        /// <param name="PDifferenceMin"></param>
        public void PDifferenceMin_Writer(String pDifferenceMin)
        {
            if (String.IsNullOrEmpty(pDifferenceMin))
                return;
            PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eMinimum).Value = pDifferenceMin;
        }

        /// <summary>
        /// Global number: 137
        /// API name: DIFFERENTIAL PRESSURE-Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Minimum"]
        /// </summary>
        /// <returns></returns>
        public String PDifferenceMin_Reader()
        {
            return PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eMinimum).Value;
        }

        /// <summary>
        /// Global number: 138
        /// API name: DIFFERENTIAL PRESSURE-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Normal"]
        /// </summary>
        /// <param name="PDifferenceNormal"></param>
        public void PDifferenceNormal_Writer(String pDifferenceNormal)
        {
            if (String.IsNullOrEmpty(pDifferenceNormal))
                return;
            PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eNormal).Value = pDifferenceNormal;
        }

        /// <summary>
        /// Global number: 138
        /// API name: DIFFERENTIAL PRESSURE-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Normal"]
        /// </summary>
        /// <returns></returns>
        public String PDifferenceNormal_Reader()
        {
            return PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eNormal).Value;
        }

        /// <summary>
        /// Global number: 140
        /// API name: Differential Pressure-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <param name="PDifferenceRated"></param>
        public void PDifferenceRated_Writer(String pDifferenceRated)
        {
            if (String.IsNullOrEmpty(pDifferenceRated))
                return;
            PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eRated).Value = pDifferenceRated;
        }

        /// <summary>
        /// Global number: 140
        /// API name: Differential Pressure-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <returns></returns>
        public String PDifferenceRated_Reader()
        {
            return PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, eqRotDoc.etl.EPropertyType.EnumValues.eRated).Value;
        }

        /// <summary>
        /// Global number: 480
        /// API name: RATED POWER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:brakePower[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <param name="PerfBrakePowerRated"></param>
        public void PerfBrakePowerRated_Writer(String perfBrakePowerRated)
        {
            if (String.IsNullOrEmpty(perfBrakePowerRated))
                return;
        }

        /// <summary>
        /// Global number: 480
        /// API name: RATED POWER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:brakePower[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <returns></returns>
        public String PerfBrakePowerRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 704
        /// API name: As Tested Curve No
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:performanceCurve[@valueSourceType="Actual"]/eqRot:curveNumber
        /// </summary>
        /// <param name="PerfCurveActualID"></param>
        public void PerfCurveActualID_Writer(String perfCurveActualID)
        {
            if (String.IsNullOrEmpty(perfCurveActualID))
                return;
        }

        /// <summary>
        /// Global number: 704
        /// API name: As Tested Curve No
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:performanceCurve[@valueSourceType="Actual"]/eqRot:curveNumber
        /// </summary>
        /// <returns></returns>
        public String PerfCurveActualID_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 125
        /// API name: PROPOSAL CURVE NO.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:performanceCurve[@valueSourceType="Estimated"]/eqRot:curveNumber
        /// </summary>
        /// <param name="PerfCurveID"></param>
        public void PerfCurveID_Writer(String perfCurveID)
        {
            if (String.IsNullOrEmpty(perfCurveID))
                return;
        }

        /// <summary>
        /// Global number: 125
        /// API name: PROPOSAL CURVE NO.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:performanceCurve[@valueSourceType="Estimated"]/eqRot:curveNumber
        /// </summary>
        /// <returns></returns>
        public String PerfCurveID_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 477
        /// API name: EFFICIENCY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:overallEfficiencyPercent[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <param name="PerfEfficiencyRated"></param>
        public void PerfEfficiencyRated_Writer(String perfEfficiencyRated)
        {
            if (String.IsNullOrEmpty(perfEfficiencyRated))
                return;
        }

        /// <summary>
        /// Global number: 477
        /// API name: EFFICIENCY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:overallEfficiencyPercent[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <returns></returns>
        public String PerfEfficiencyRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 312
        /// API name: Max Allow Flow-TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:maxFlowVolume[@valueSourceType="Allowable"]
        /// </summary>
        /// <param name="PerfFlowVolumeAllowableMax"></param>
        public void PerfFlowVolumeAllowableMax_Writer(String perfFlowVolumeAllowableMax)
        {
            if (String.IsNullOrEmpty(perfFlowVolumeAllowableMax))
                return;
        }

        /// <summary>
        /// Global number: 312
        /// API name: Max Allow Flow-TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:maxFlowVolume[@valueSourceType="Allowable"]
        /// </summary>
        /// <returns></returns>
        public String PerfFlowVolumeAllowableMax_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 339
        /// API name: ALLOWABLE OPER. REGION-FROM
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minFlowVolume[@valueSourceType="Allowable"]
        /// </summary>
        /// <param name="PerfFlowVolumeAllowableMin"></param>
        public void PerfFlowVolumeAllowableMin_Writer(String perfFlowVolumeAllowableMin)
        {
            if (String.IsNullOrEmpty(perfFlowVolumeAllowableMin))
                return;
        }

        /// <summary>
        /// Global number: 339
        /// API name: ALLOWABLE OPER. REGION-FROM
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minFlowVolume[@valueSourceType="Allowable"]
        /// </summary>
        /// <returns></returns>
        public String PerfFlowVolumeAllowableMin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 432
        /// API name: PREFERRED OPER. REGION-TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:maxFlowVolume[@valueSourceType="Preferred"]
        /// </summary>
        /// <param name="PerfFlowVolumePreferredMax"></param>
        public void PerfFlowVolumePreferredMax_Writer(String perfFlowVolumePreferredMax)
        {
            if (String.IsNullOrEmpty(perfFlowVolumePreferredMax))
                return;
        }

        /// <summary>
        /// Global number: 432
        /// API name: PREFERRED OPER. REGION-TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:maxFlowVolume[@valueSourceType="Preferred"]
        /// </summary>
        /// <returns></returns>
        public String PerfFlowVolumePreferredMax_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 433
        /// API name: PREFERRED OPER. REGION-FROM
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minFlowVolume[@valueSourceType="Preferred"]
        /// </summary>
        /// <param name="PerfFlowVolumePreferredMin"></param>
        public void PerfFlowVolumePreferredMin_Writer(String perfFlowVolumePreferredMin)
        {
            if (String.IsNullOrEmpty(perfFlowVolumePreferredMin))
                return;
        }

        /// <summary>
        /// Global number: 433
        /// API name: PREFERRED OPER. REGION-FROM
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minFlowVolume[@valueSourceType="Preferred"]
        /// </summary>
        /// <returns></returns>
        public String PerfFlowVolumePreferredMin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 315
        /// API name: MAX HEAD @ RATED IMPELLER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"]/eqRot:head[@referenceProperty="Impeller Diameter, Rated"]
        /// </summary>
        /// <param name="PerfMaxHeadAtRatedImpeller"></param>
        public void PerfMaxHeadAtRatedImpeller_Writer(String perfMaxHeadAtRatedImpeller)
        {
            if (String.IsNullOrEmpty(perfMaxHeadAtRatedImpeller))
                return;
        }

        /// <summary>
        /// Global number: 315
        /// API name: MAX HEAD @ RATED IMPELLER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"]/eqRot:head[@referenceProperty="Impeller Diameter, Rated"]
        /// </summary>
        /// <returns></returns>
        public String PerfMaxHeadAtRatedImpeller_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 786
        /// API name: NPSH Margin at Rated Flow
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:npsh[@usageContext="Operating performance"][@valueSourceType="Margin"][@referenceProperty="Flowrate at Rated Condition"]
        /// </summary>
        /// <param name="PerfNPSHMargin"></param>
        public void PerfNPSHMargin_Writer(String perfNPSHMargin)
        {
            if (String.IsNullOrEmpty(perfNPSHMargin))
                return;
        }

        /// <summary>
        /// Global number: 786
        /// API name: NPSH Margin at Rated Flow
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:npsh[@usageContext="Operating performance"][@valueSourceType="Margin"][@referenceProperty="Flowrate at Rated Condition"]
        /// </summary>
        /// <returns></returns>
        public String PerfNPSHMargin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 462
        /// API name: SPECIFIC SPEED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:pumpSpecificSpeed
        /// </summary>
        /// <param name="PerfPumpSpecificSpeed"></param>
        public void PerfPumpSpecificSpeed_Writer(String perfPumpSpecificSpeed)
        {
            if (String.IsNullOrEmpty(perfPumpSpecificSpeed))
                return;
        }

        /// <summary>
        /// Global number: 462
        /// API name: SPECIFIC SPEED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:pumpSpecificSpeed
        /// </summary>
        /// <returns></returns>
        public String PerfPumpSpecificSpeed_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 326
        /// API name: MINIMUM CONTINUOUS FLOW-STABLE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minStableFlowVolume
        /// </summary>
        /// <param name="PerfStableFlowVolumeMin"></param>
        public void PerfStableFlowVolumeMin_Writer(String perfStableFlowVolumeMin)
        {
            if (String.IsNullOrEmpty(perfStableFlowVolumeMin))
                return;
        }

        /// <summary>
        /// Global number: 326
        /// API name: MINIMUM CONTINUOUS FLOW-STABLE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minStableFlowVolume
        /// </summary>
        /// <returns></returns>
        public String PerfStableFlowVolumeMin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 581
        /// API name: SUCTION SPECIFIC SPEED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:suctionSpecificSpeed
        /// </summary>
        /// <param name="PerfSuctionSpecificSpeed"></param>
        public void PerfSuctionSpecificSpeed_Writer(String perfSuctionSpecificSpeed)
        {
            if (String.IsNullOrEmpty(perfSuctionSpecificSpeed))
                return;
        }

        /// <summary>
        /// Global number: 581
        /// API name: SUCTION SPECIFIC SPEED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:suctionSpecificSpeed
        /// </summary>
        /// <returns></returns>
        public String PerfSuctionSpecificSpeed_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 682
        /// API name: SUCTION SPECIFIC SPEED LIMIT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:suctionSpecificSpeedLimit
        /// </summary>
        /// <param name="PerfSuctionSpecificSpeedLimit"></param>
        public void PerfSuctionSpecificSpeedLimit_Writer(String perfSuctionSpecificSpeedLimit)
        {
            if (String.IsNullOrEmpty(perfSuctionSpecificSpeedLimit))
                return;
        }

        /// <summary>
        /// Global number: 682
        /// API name: SUCTION SPECIFIC SPEED LIMIT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:suctionSpecificSpeedLimit
        /// </summary>
        /// <returns></returns>
        public String PerfSuctionSpecificSpeedLimit_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 327
        /// API name: MINIMUM CONTINUOUS FLOW-THERMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minThermalFlowVolume
        /// </summary>
        /// <param name="PerfThermalFlowVolumeMin"></param>
        public void PerfThermalFlowVolumeMin_Writer(String perfThermalFlowVolumeMin)
        {
            if (String.IsNullOrEmpty(perfThermalFlowVolumeMin))
                return;
        }

        /// <summary>
        /// Global number: 327
        /// API name: MINIMUM CONTINUOUS FLOW-THERMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:operatingRegion/eqRot:minThermalFlowVolume
        /// </summary>
        /// <returns></returns>
        public String PerfThermalFlowVolumeMin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 443
        /// API name: UNIT-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/objb:name
        /// </summary>
        /// <param name="ProcessUnit"></param>
        public void ProcessUnit_Writer(String processUnit)
        {
            if (String.IsNullOrEmpty(processUnit))
                return;
            eqRotDoc.site.FacilitySystem fSystem = facilitySystem();

            if (!fSystem.name.Exists)
            {
                fSystem.name.Append();
            }

            fSystem.name.First.Value = processUnit;
        }

        /// <summary>
        /// Global number: 443
        /// API name: UNIT-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/objb:name
        /// </summary>
        /// <returns></returns>
        public String ProcessUnit_Reader()
        {
            eqRotDoc.site.FacilitySystem fSystem = facilitySystem();

            if (!fSystem.name.Exists)
            {
                return null;
            }

            return fSystem.name.First.Value;
        }

        /// <summary>
        /// Global number: 14
        /// API name: APPLICABLE NTL/INTNTL STANDARD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:pumpDesignStandard
        /// </summary>
        /// <param name="PumpDesignStandard"></param>
        public void PumpDesignStandard_Writer(String pumpDesignStandard)
        {
            if (String.IsNullOrEmpty(pumpDesignStandard))
                return;
            eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues value = cfiXML_Enums.getPumpDesignStandard(pumpDesignStandard);

            eqRotDoc.eqRot.applicableStandardType4 appStandardType = applicableStandard();

            if (!appStandardType.pumpDesignStandard.Exists)
            {
                appStandardType.pumpDesignStandard.Append();
            }

            if (value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eOther) || value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ecustom)) // Verifiquei no xsd e invalid é usado só na programação. Diz que a varaivel ainda não foi setada.
            {// Tem que criar o nó other ja que o valor que vou escrever no xml nao tem no enumeration.
                // ver como funciona isso na norma
                appStandardType.pumpDesignStandard.First.EnumerationValue = value;
                appStandardType.pumpDesignStandard.First.otherValue.Value = pumpDesignStandard;
            }
            else
            {
                appStandardType.pumpDesignStandard.First.EnumerationValue = value;
            }
        }

        /// <summary>
        /// Global number: 14
        /// API name: APPLICABLE NTL/INTNTL STANDARD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:pumpDesignStandard
        /// </summary>
        /// <returns></returns>
        public String PumpDesignStandard_Reader()
        {
            eqRotDoc.eqRot.applicableStandardType4 appStandardType = applicableStandard();

            if (!appStandardType.pumpDesignStandard.Exists)
            {
                return null;
            }

            eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues value = appStandardType.pumpDesignStandard.First.EnumerationValue;

            if (value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eOther) || value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ecustom))
            {
                return appStandardType.pumpDesignStandard.First.otherValue.Value;
            }

            return Utils.processEnumValue(value.ToString());
        }

        /// <summary>
        /// Global number: 856
        /// API name: VARIABLE SPEED REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqRot:isVariableSpeedRequired
        /// </summary>
        /// <param name="PumpDriverVariableSpeedRequired"></param>
        public void PumpDriverVariableSpeedRequired_Writer(String pumpDriverVariableSpeedRequired)
        {
            if (String.IsNullOrEmpty(pumpDriverVariableSpeedRequired))
                return;
        }

        /// <summary>
        /// Global number: 856
        /// API name: VARIABLE SPEED REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqRot:isVariableSpeedRequired
        /// </summary>
        /// <returns></returns>
        public String PumpDriverVariableSpeedRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 825
        /// API name: SOURCE OF VARIABLE SPEED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqRot:variableSpeedSource
        /// </summary>
        /// <param name="PumpDriverVariableSpeedSource"></param>
        public void PumpDriverVariableSpeedSource_Writer(String pumpDriverVariableSpeedSource)
        {
            if (String.IsNullOrEmpty(pumpDriverVariableSpeedSource))
                return;
        }

        /// <summary>
        /// Global number: 825
        /// API name: SOURCE OF VARIABLE SPEED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqRot:variableSpeedSource
        /// </summary>
        /// <returns></returns>
        public String PumpDriverVariableSpeedSource_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 550
        /// API name: SPECIFIC HEAT-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:cpMass
        /// </summary>
        /// <param name="PumpFluidCpMassAtMaxT"></param>
        public void PumpFluidCpMassAtMaxT_Writer(String pumpFluidCpMassAtMaxT)
        {
            if (String.IsNullOrEmpty(pumpFluidCpMassAtMaxT))
                return;
        }

        /// <summary>
        /// Global number: 550
        /// API name: SPECIFIC HEAT-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:cpMass
        /// </summary>
        /// <returns></returns>
        public String PumpFluidCpMassAtMaxT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 346
        /// API name: SPECIFIC HEAT-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:cpMass
        /// </summary>
        /// <param name="PumpFluidCpMassAtMinT"></param>
        public void PumpFluidCpMassAtMinT_Writer(String pumpFluidCpMassAtMinT)
        {
            if (String.IsNullOrEmpty(pumpFluidCpMassAtMinT))
                return;
        }

        /// <summary>
        /// Global number: 346
        /// API name: SPECIFIC HEAT-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:cpMass
        /// </summary>
        /// <returns></returns>
        public String PumpFluidCpMassAtMinT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1921
        /// API name: VISCOSITY (cP)         -MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:viscosity
        /// </summary>
        /// <param name="PumpFluidDynamicViscosityAtMaxT"></param>
        public void PumpFluidDynamicViscosityAtMaxT_Writer(String pumpFluidDynamicViscosityAtMaxT)
        {
            if (String.IsNullOrEmpty(pumpFluidDynamicViscosityAtMaxT))
                return;
        }

        /// <summary>
        /// Global number: 1921
        /// API name: VISCOSITY (cP)         -MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:viscosity
        /// </summary>
        /// <returns></returns>
        public String PumpFluidDynamicViscosityAtMaxT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1923
        /// API name: Viscosity-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:viscosity
        /// </summary>
        /// <param name="PumpFluidDynamicViscosityAtMinT"></param>
        public void PumpFluidDynamicViscosityAtMinT_Writer(String pumpFluidDynamicViscosityAtMinT)
        {
            if (String.IsNullOrEmpty(pumpFluidDynamicViscosityAtMinT))
                return;
        }

        /// <summary>
        /// Global number: 1923
        /// API name: Viscosity-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:viscosity
        /// </summary>
        /// <returns></returns>
        public String PumpFluidDynamicViscosityAtMinT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 249
        /// API name: H2S CONCENTRATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"]/mtrl:hydrogenSulfidePPM
        /// </summary>
        /// <param name="PumpFluidHydrogenSulfidePPM"></param>
        public void PumpFluidHydrogenSulfidePPM_Writer(String pumpFluidHydrogenSulfidePPM)
        {
            if (String.IsNullOrEmpty(pumpFluidHydrogenSulfidePPM))
                return;
        }

        /// <summary>
        /// Global number: 249
        /// API name: H2S CONCENTRATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"]/mtrl:hydrogenSulfidePPM
        /// </summary>
        /// <returns></returns>
        public String PumpFluidHydrogenSulfidePPM_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 293
        /// API name: Liquid Name
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/objb:name
        /// </summary>
        /// <param name="PumpFluidName"></param>
        public void PumpFluidName_Writer(String pumpFluidName)
        {
            if (String.IsNullOrEmpty(pumpFluidName))
                return;
            eqRotDoc.uo.MaterialStream mStream = materialStream_OperatingPerformance(eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mStream.name.Exists)
            {
                mStream.name.Append();
            }

            mStream.name.First.Value = pumpFluidName;
        }

        /// <summary>
        /// Global number: 293
        /// API name: Liquid Name
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/objb:name
        /// </summary>
        /// <returns></returns>
        public String PumpFluidName_Reader()
        {
            eqRotDoc.uo.MaterialStream mStream = materialStream_OperatingPerformance(eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mStream.name.Exists)
            {
                return null;
            }

            return mStream.name.First.Value;
        }

        /// <summary>
        /// Global number: 796
        /// API name: PARTICULATE SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"]/mtrl:particleDiameter
        /// </summary>
        /// <param name="PumpFluidParticleDiameter"></param>
        public void PumpFluidParticleDiameter_Writer(String pumpFluidParticleDiameter)
        {
            if (String.IsNullOrEmpty(pumpFluidParticleDiameter))
                return;
        }

        /// <summary>
        /// Global number: 796
        /// API name: PARTICULATE SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"]/mtrl:particleDiameter
        /// </summary>
        /// <returns></returns>
        public String PumpFluidParticleDiameter_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 795
        /// API name: PARTICULATE CONCENTRATION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"]/mtrl:particulatePPM
        /// </summary>
        /// <param name="PumpFluidParticulatePPM"></param>
        public void PumpFluidParticulatePPM_Writer(String pumpFluidParticulatePPM)
        {
            if (String.IsNullOrEmpty(pumpFluidParticulatePPM))
                return;
        }

        /// <summary>
        /// Global number: 795
        /// API name: PARTICULATE CONCENTRATION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"]/mtrl:particulatePPM
        /// </summary>
        /// <returns></returns>
        public String PumpFluidParticulatePPM_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 314
        /// API name: RELATIVE DENSITY-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:specificGravity
        /// </summary>
        /// <param name="PumpFluidSGAtMaxT"></param>
        public void PumpFluidSGAtMaxT_Writer(String pumpFluidSGAtMaxT)
        {
            if (String.IsNullOrEmpty(pumpFluidSGAtMaxT))
                return;
        }

        /// <summary>
        /// Global number: 314
        /// API name: RELATIVE DENSITY-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:specificGravity
        /// </summary>
        /// <returns></returns>
        public String PumpFluidSGAtMaxT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 341
        /// API name: RELATIVE DENSITY-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:specificGravity
        /// </summary>
        /// <param name="PumpFluidSGAtMinT"></param>
        public void PumpFluidSGAtMinT_Writer(String pumpFluidSGAtMinT)
        {
            if (String.IsNullOrEmpty(pumpFluidSGAtMinT))
                return;
        }

        /// <summary>
        /// Global number: 341
        /// API name: RELATIVE DENSITY-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:specificGravity
        /// </summary>
        /// <returns></returns>
        public String PumpFluidSGAtMinT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 320
        /// API name: PUMPING TEMP-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:t
        /// </summary>
        /// <param name="PumpFluidTMax"></param>
        public void PumpFluidTMax_Writer(String pumpFluidTMax)
        {
            if (String.IsNullOrEmpty(pumpFluidTMax))
                return;
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                mProperty.t.Append();
            }

            mProperty.t.First.Value = pumpFluidTMax;
            mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Max";
        }

        /// <summary>
        /// Global number: 320
        /// API name: PUMPING TEMP-MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:t
        /// </summary>
        /// <returns></returns>
        public String PumpFluidTMax_Reader()
        {
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                return null;
            }

            return mProperty.t.First.Value;
        }

        /// <summary>
        /// Global number: 345
        /// API name: PUMPING TEMP-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:t
        /// </summary>
        /// <param name="PumpFluidTMin"></param>
        public void PumpFluidTMin_Writer(String pumpFluidTMin)
        {
            if (String.IsNullOrEmpty(pumpFluidTMin))
                return;
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                mProperty.t.Append();
            }

            mProperty.t.First.Value = pumpFluidTMin;
            mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Min";
        }

        /// <summary>
        /// Global number: 345
        /// API name: PUMPING TEMP-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:t
        /// </summary>
        /// <returns></returns>
        public String PumpFluidTMin_Reader()
        {
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                return null;
            }

            return mProperty.t.First.Value;
        }

        /// <summary>
        /// Global number: 375
        /// API name: PUMPING TEMP-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:t
        /// </summary>
        /// <param name="PumpFluidTNormal"></param>
        public void PumpFluidTNormal_Writer(String pumpFluidTNormal)
        {
            if (String.IsNullOrEmpty(pumpFluidTNormal))
                return;
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                mProperty.t.Append();
            }

            mProperty.t.First.Value = pumpFluidTNormal;
            mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Normal";
        }

        /// <summary>
        /// Global number: 375
        /// API name: PUMPING TEMP-NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:t
        /// </summary>
        /// <returns></returns>
        public String PumpFluidTNormal_Reader()
        {
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                return null;
            }

            return mProperty.t.First.Value;
        }

        /// <summary>
        /// Global number: 452
        /// API name: PUMPING_TEMPERATURE_RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Rated"]/mtrl:t
        /// </summary>
        /// <param name="PumpFluidTRated"></param>
        public void PumpFluidTRated_Writer(String pumpFluidTRated)
        {
            if (String.IsNullOrEmpty(pumpFluidTRated))
                return;
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                mProperty.t.Append();
            }

            mProperty.t.First.Value = pumpFluidTRated;
            mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Rated";
        }

        /// <summary>
        /// Global number: 452
        /// API name: PUMPING_TEMPERATURE_RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Rated"]/mtrl:t
        /// </summary>
        /// <returns></returns>
        public String PumpFluidTRated_Reader()
        {
            eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (!mProperty.t.Exists)
            {
                return null;
            }

            return mProperty.t.First.Value;
        }

        /// <summary>
        /// Global number: 324
        /// API name: VAPOR PRESS. -MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:vaporP
        /// </summary>
        /// <param name="PumpFluidVaporPAtMaxT"></param>
        public void PumpFluidVaporPAtMaxT_Writer(String pumpFluidVaporPAtMaxT)
        {
            if (String.IsNullOrEmpty(pumpFluidVaporPAtMaxT))
                return;
        }

        /// <summary>
        /// Global number: 324
        /// API name: VAPOR PRESS. -MAX.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:vaporP
        /// </summary>
        /// <returns></returns>
        public String PumpFluidVaporPAtMaxT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 349
        /// API name: VAPOR PRESS. -MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:vaporP
        /// </summary>
        /// <param name="PumpFluidVaporPAtMinT"></param>
        public void PumpFluidVaporPAtMinT_Writer(String pumpFluidVaporPAtMinT)
        {
            if (String.IsNullOrEmpty(pumpFluidVaporPAtMinT))
                return;
        }

        /// <summary>
        /// Global number: 349
        /// API name: VAPOR PRESS. -MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:vaporP
        /// </summary>
        /// <returns></returns>
        public String PumpFluidVaporPAtMinT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 102
        /// API name: CORROSION DUE TO-2 lines required
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"][mtrl:isHazardous="true"]/mtrl:description
        /// </summary>
        /// <param name="PumpHazardousFluidDesc"></param>
        public void PumpHazardousFluidDesc_Writer(String pumpHazardousFluidDesc)
        {
            if (String.IsNullOrEmpty(pumpHazardousFluidDesc))
                return;
        }

        /// <summary>
        /// Global number: 102
        /// API name: CORROSION DUE TO-2 lines required
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Unspecified"][mtrl:isHazardous="true"]/mtrl:description
        /// </summary>
        /// <returns></returns>
        public String PumpHazardousFluidDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 457
        /// API name: MANUFACTURER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/ctx:manufacturerCompany/objb:name
        /// </summary>
        /// <param name="PumpManufacturer"></param>
        public void PumpManufacturer_Writer(String pumpManufacturer)
        {
            if (String.IsNullOrEmpty(pumpManufacturer))
                return;
            Organization mCompany = manufacturerCompany();

            if (!mCompany.name.Exists)
            {
                mCompany.name.Append();
            }

            mCompany.name.First.Value = pumpManufacturer;
        }

        /// <summary>
        /// Global number: 457
        /// API name: MANUFACTURER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/ctx:manufacturerCompany/objb:name
        /// </summary>
        /// <returns></returns>
        public String PumpManufacturer_Reader()
        {
            Organization mCompany = manufacturerCompany();

            if (!mCompany.name.Exists)
            {
                return null;
            }

            return mCompany.name.First.Value;
        }

        /// <summary>
        /// Global number: 458
        /// API name: MODEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:model
        /// </summary>
        /// <param name="PumpModel"></param>
        public void PumpModel_Writer(String pumpModel)
        {
            if (String.IsNullOrEmpty(pumpModel))
                return;
            eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

            if (!cPumpID.model.Exists)
            {
                cPumpID.model.Append();
            }

            cPumpID.model.First.Value = pumpModel;
        }

        /// <summary>
        /// Global number: 458
        /// API name: MODEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:model
        /// </summary>
        /// <returns></returns>
        public String PumpModel_Reader()
        {
            eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

            if (!cPumpID.model.Exists)
            {
                return null;
            }

            return cPumpID.model.First.Value;
        }

        /// <summary>
        /// Global number: 555
        /// API name: NO. STAGES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:numberStage
        /// </summary>
        /// <param name="PumpNumberOfStage"></param>
        public void PumpNumberOfStage_Writer(String pumpNumberOfStage)
        {
            if (String.IsNullOrEmpty(pumpNumberOfStage))
                return;
            eqRotDoc.eqRot.CentrifugalPump cPump = centrifugalPump();

            if (!cPump.numberStage.Exists)
            {
                cPump.numberStage.Append();
            }

            cPump.numberStage.First.Value = pumpNumberOfStage;
        }

        /// <summary>
        /// Global number: 555
        /// API name: NO. STAGES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:numberStage
        /// </summary>
        /// <returns></returns>
        public String PumpNumberOfStage_Reader()
        {
            eqRotDoc.eqRot.CentrifugalPump cPump = centrifugalPump();

            if (!cPump.numberStage.Exists)
            {
                return null;
            }

            return cPump.numberStage.First.Value;
        }

        /// <summary>
        /// Global number: 461
        /// API name: PUMP SIZE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partSize
        /// </summary>
        /// <param name="PumpPartSize"></param>
        public void PumpPartSize_Writer(String pumpPartSize)
        {
            if (String.IsNullOrEmpty(pumpPartSize))
                return;
            eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

            if (!cPumpID.partSize.Exists)
            {
                cPumpID.partSize.Append();
            }

            cPumpID.partSize.First.Value = pumpPartSize;
        }

        /// <summary>
        /// Global number: 461
        /// API name: PUMP SIZE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partSize
        /// </summary>
        /// <returns></returns>
        public String PumpPartSize_Reader()
        {
            eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

            if (!cPumpID.partSize.Exists)
            {
                return null;
            }

            return cPumpID.partSize.First.Value;
        }

        /// <summary>
        /// Global number: 688
        /// API name: TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partType
        /// </summary>
        /// <param name="PumpPartType"></param>
        public void PumpPartType_Writer(String pumpPartType)
        {
            if (String.IsNullOrEmpty(pumpPartType))
                return;
            eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

            if (!cPumpID.partType.Exists)
            {
                cPumpID.partType.Append();
            }

            cPumpID.partType.First.Value = pumpPartType;
        }

        /// <summary>
        /// Global number: 688
        /// API name: TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partType
        /// </summary>
        /// <returns></returns>
        public String PumpPartType_Reader()
        {
            eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

            if (!cPumpID.partType.Exists)
            {
                return null;
            }

            return cPumpID.partType.First.Value;
        }

        /// <summary>
        /// Global number: 481
        /// API name: RPM-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:rotationalSpeed[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <param name="PumpPerfRatedSpeed"></param>
        public void PumpPerfRatedSpeed_Writer(String pumpPerfRatedSpeed)
        {
            if (String.IsNullOrEmpty(pumpPerfRatedSpeed))
                return;
        }

        /// <summary>
        /// Global number: 481
        /// API name: RPM-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:rotationalSpeed[@usageContext="Operating performance"][@propertyType="Rated"]
        /// </summary>
        /// <returns></returns>
        public String PumpPerfRatedSpeed_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 391
        /// API name: NO. REQ-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/dx:orderLine/dx:quantity
        /// </summary>
        /// <param name="PumpQuantity"></param>
        public void PumpQuantity_Writer(String pumpQuantity)
        {
            if (String.IsNullOrEmpty(pumpQuantity))
                return;
            OrderLine oLine = orderLine();

            if (!oLine.quantity.Exists)
            {
                oLine.quantity.Append();
            }

            oLine.quantity.First.Value = pumpQuantity;
        }

        /// <summary>
        /// Global number: 391
        /// API name: NO. REQ-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/dx:orderLine/dx:quantity
        /// </summary>
        /// <returns></returns>
        public String PumpQuantity_Reader()
        {
            OrderLine oLine = orderLine();

            if (!oLine.quantity.Exists)
            {
                return null;
            }

            return oLine.quantity.First.Value;
        }

        /// <summary>
        /// Global number: 1750
        /// API name: Starting Method-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:start/eqRot:systemStartingState
        /// </summary>
        /// <param name="PumpSystemStartingState"></param>
        public void PumpSystemStartingState_Writer(String pumpSystemStartingState)
        {
            if (String.IsNullOrEmpty(pumpSystemStartingState))
                return;
        }

        /// <summary>
        /// Global number: 1750
        /// API name: Starting Method-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:start/eqRot:systemStartingState
        /// </summary>
        /// <returns></returns>
        public String PumpSystemStartingState_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 719
        /// API name: CL pump to U/S baseplate
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpToBaseplateLength
        /// </summary>
        /// <param name="PumpToBaseplateLength"></param>
        public void PumpToBaseplateLength_Writer(String pumpToBaseplateLength)
        {
            if (String.IsNullOrEmpty(pumpToBaseplateLength))
                return;
        }

        /// <summary>
        /// Global number: 719
        /// API name: CL pump to U/S baseplate
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpToBaseplateLength
        /// </summary>
        /// <returns></returns>
        public String PumpToBaseplateLength_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 727
        /// API name: CONTROL-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Control"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <param name="SiteElectricUtilityControlFrequency"></param>
        public void SiteElectricUtilityControlFrequency_Writer(String siteElectricUtilityControlFrequency)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityControlFrequency))
                return;
        }

        /// <summary>
        /// Global number: 727
        /// API name: CONTROL-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Control"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityControlFrequency_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 728
        /// API name: CONTROL-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Control"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <param name="SiteElectricUtilityControlPhase"></param>
        public void SiteElectricUtilityControlPhase_Writer(String siteElectricUtilityControlPhase)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityControlPhase))
                return;
        }

        /// <summary>
        /// Global number: 728
        /// API name: CONTROL-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Control"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityControlPhase_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 729
        /// API name: CONTROL-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Control"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <param name="SiteElectricUtilityControlVoltage"></param>
        public void SiteElectricUtilityControlVoltage_Writer(String siteElectricUtilityControlVoltage)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityControlVoltage))
                return;
        }

        /// <summary>
        /// Global number: 729
        /// API name: CONTROL-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Control"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityControlVoltage_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 191
        /// API name: DRIVERS-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <param name="SiteElectricUtilityDriverFrequency"></param>
        public void SiteElectricUtilityDriverFrequency_Writer(String siteElectricUtilityDriverFrequency)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityDriverFrequency))
                return;
        }

        /// <summary>
        /// Global number: 191
        /// API name: DRIVERS-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityDriverFrequency_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 192
        /// API name: DRIVERS-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <param name="SiteElectricUtilityDriverPhase"></param>
        public void SiteElectricUtilityDriverPhase_Writer(String siteElectricUtilityDriverPhase)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityDriverPhase))
                return;
        }

        /// <summary>
        /// Global number: 192
        /// API name: DRIVERS-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityDriverPhase_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 193
        /// API name: DRIVERS-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <param name="SiteElectricUtilityDriverVoltage"></param>
        public void SiteElectricUtilityDriverVoltage_Writer(String siteElectricUtilityDriverVoltage)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityDriverVoltage))
                return;
        }

        /// <summary>
        /// Global number: 193
        /// API name: DRIVERS-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityDriverVoltage_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 194
        /// API name: Electric HEATING-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <param name="SiteElectricUtilityHeaterFrequency"></param>
        public void SiteElectricUtilityHeaterFrequency_Writer(String siteElectricUtilityHeaterFrequency)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityHeaterFrequency))
                return;
        }

        /// <summary>
        /// Global number: 194
        /// API name: Electric HEATING-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityHeaterFrequency_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 195
        /// API name: Electric HEATING-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <param name="SiteElectricUtilityHeaterPhase"></param>
        public void SiteElectricUtilityHeaterPhase_Writer(String siteElectricUtilityHeaterPhase)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityHeaterPhase))
                return;
        }

        /// <summary>
        /// Global number: 195
        /// API name: Electric HEATING-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityHeaterPhase_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 196
        /// API name: Electric HEATING-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <param name="SiteElectricUtilityHeaterVoltage"></param>
        public void SiteElectricUtilityHeaterVoltage_Writer(String siteElectricUtilityHeaterVoltage)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityHeaterVoltage))
                return;
        }

        /// <summary>
        /// Global number: 196
        /// API name: Electric HEATING-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityHeaterVoltage_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 818
        /// API name: SHUTDOWN-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Alarm and Shutdown system"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <param name="SiteElectricUtilityShutdownFrequency"></param>
        public void SiteElectricUtilityShutdownFrequency_Writer(String siteElectricUtilityShutdownFrequency)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityShutdownFrequency))
                return;
        }

        /// <summary>
        /// Global number: 818
        /// API name: SHUTDOWN-HERTZ
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Alarm and Shutdown system"]/etl:electricalSupplyCharacteristic/etl:frequency
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityShutdownFrequency_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 819
        /// API name: SHUTDOWN-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Alarm and Shutdown system"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <param name="SiteElectricUtilityShutdownPhase"></param>
        public void SiteElectricUtilityShutdownPhase_Writer(String siteElectricUtilityShutdownPhase)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityShutdownPhase))
                return;
        }

        /// <summary>
        /// Global number: 819
        /// API name: SHUTDOWN-PHASE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Alarm and Shutdown system"]/etl:electricalSupplyCharacteristic/etl:electricalPhase
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityShutdownPhase_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 820
        /// API name: SHUTDOWN-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Alarm and Shutdown system"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <param name="SiteElectricUtilityShutdownVoltage"></param>
        public void SiteElectricUtilityShutdownVoltage_Writer(String siteElectricUtilityShutdownVoltage)
        {
            if (String.IsNullOrEmpty(siteElectricUtilityShutdownVoltage))
                return;
        }

        /// <summary>
        /// Global number: 820
        /// API name: SHUTDOWN-VOLTAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:electricalUtilityServiceProvided[eq:utilityDemandDeviceType="Alarm and Shutdown system"]/etl:electricalSupplyCharacteristic/etl:voltage
        /// </summary>
        /// <returns></returns>
        public String SiteElectricUtilityShutdownVoltage_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 7
        /// API name: ELEVATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/ctx:locationAndGeographicArea/ctx:geographicArea/ctx:elevation
        /// </summary>
        /// <param name="SiteElevation"></param>
        public void SiteElevation_Writer(String siteElevation)
        {
            if (String.IsNullOrEmpty(siteElevation))
                return;
        }

        /// <summary>
        /// Global number: 7
        /// API name: ELEVATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/ctx:locationAndGeographicArea/ctx:geographicArea/ctx:elevation
        /// </summary>
        /// <returns></returns>
        public String SiteElevation_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 92
        /// API name: COOLING WATER CHLORIDE CONCENTRATION:-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/mtrl:materialProperty/mtrl:property/mtrl:chloridePPM
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterChlorideConc"></param>
        public void SiteMtrlUtilityCoolingWaterChlorideConc_Writer(String siteMtrlUtilityCoolingWaterChlorideConc)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterChlorideConc))
                return;
        }

        /// <summary>
        /// Global number: 92
        /// API name: COOLING WATER CHLORIDE CONCENTRATION:-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/mtrl:materialProperty/mtrl:property/mtrl:chloridePPM
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterChlorideConc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 93
        /// API name: Cooling Water - Min Design Pressure
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:designP[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterDesignP"></param>
        public void SiteMtrlUtilityCoolingWaterDesignP_Writer(String siteMtrlUtilityCoolingWaterDesignP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterDesignP))
                return;
        }

        /// <summary>
        /// Global number: 93
        /// API name: Cooling Water - Min Design Pressure
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:designP[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterDesignP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 849
        /// API name: Cooling Water - Max Design Temp
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:designT
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterDesignT"></param>
        public void SiteMtrlUtilityCoolingWaterDesignT_Writer(String siteMtrlUtilityCoolingWaterDesignT)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterDesignT))
                return;
        }

        /// <summary>
        /// Global number: 849
        /// API name: Cooling Water - Max Design Temp
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:designT
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterDesignT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 97
        /// API name: Cooling Water - Max Return Temp
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Return"][etl:propertyType="Maximum"]/eq:t
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterMaxReturnT"></param>
        public void SiteMtrlUtilityCoolingWaterMaxReturnT_Writer(String siteMtrlUtilityCoolingWaterMaxReturnT)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterMaxReturnT))
                return;
        }

        /// <summary>
        /// Global number: 97
        /// API name: Cooling Water - Max Return Temp
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Return"][etl:propertyType="Maximum"]/eq:t
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterMaxReturnT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 95
        /// API name: Cooling Water - Min Return Pressure
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Return"][etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterMinReturnP"></param>
        public void SiteMtrlUtilityCoolingWaterMinReturnP_Writer(String siteMtrlUtilityCoolingWaterMinReturnP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterMinReturnP))
                return;
        }

        /// <summary>
        /// Global number: 95
        /// API name: Cooling Water - Min Return Pressure
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Return"][etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterMinReturnP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 98
        /// API name: CoolWaterSOURCE-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:source
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterSource"></param>
        public void SiteMtrlUtilityCoolingWaterSource_Writer(String siteMtrlUtilityCoolingWaterSource)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterSource))
                return;
        }

        /// <summary>
        /// Global number: 98
        /// API name: CoolWaterSOURCE-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:source
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterSource_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 798
        /// API name: PRESS-INLET
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Supply"][etl:propertyType="Unspecified"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterSupplyP"></param>
        public void SiteMtrlUtilityCoolingWaterSupplyP_Writer(String siteMtrlUtilityCoolingWaterSupplyP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterSupplyP))
                return;
        }

        /// <summary>
        /// Global number: 798
        /// API name: PRESS-INLET
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Supply"][etl:propertyType="Unspecified"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterSupplyP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 99
        /// API name: CoolWaterTEMP-INLET
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Supply"][etl:propertyType="Unspecified"]/eq:t
        /// </summary>
        /// <param name="SiteMtrlUtilityCoolingWaterSupplyT"></param>
        public void SiteMtrlUtilityCoolingWaterSupplyT_Writer(String siteMtrlUtilityCoolingWaterSupplyT)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityCoolingWaterSupplyT))
                return;
        }

        /// <summary>
        /// Global number: 99
        /// API name: CoolWaterTEMP-INLET
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:materialUtilityServiceType="Cooling water"]/eq:materialUtilityCondition[eq:utilityConnectionType="Supply"][etl:propertyType="Unspecified"]/eq:t
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityCoolingWaterSupplyT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 560
        /// API name: Steam DRIVERS-MAX. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityDriverSteamMaxP"></param>
        public void SiteMtrlUtilityDriverSteamMaxP_Writer(String siteMtrlUtilityDriverSteamMaxP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityDriverSteamMaxP))
                return;
        }

        /// <summary>
        /// Global number: 560
        /// API name: Steam DRIVERS-MAX. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityDriverSteamMaxP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 561
        /// API name: Steam DRIVERS-MAX. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:t
        /// </summary>
        /// <param name="SiteMtrlUtilityDriverSteamMaxT"></param>
        public void SiteMtrlUtilityDriverSteamMaxT_Writer(String siteMtrlUtilityDriverSteamMaxT)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityDriverSteamMaxT))
                return;
        }

        /// <summary>
        /// Global number: 561
        /// API name: Steam DRIVERS-MAX. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:t
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityDriverSteamMaxT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 562
        /// API name: Steam DRIVERS-MIN. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityDriverSteamMinP"></param>
        public void SiteMtrlUtilityDriverSteamMinP_Writer(String siteMtrlUtilityDriverSteamMinP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityDriverSteamMinP))
                return;
        }

        /// <summary>
        /// Global number: 562
        /// API name: Steam DRIVERS-MIN. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityDriverSteamMinP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 563
        /// API name: Steam DRIVERS-MIN. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:t
        /// </summary>
        /// <param name="SiteMtrlUtilityDriverSteamMinT"></param>
        public void SiteMtrlUtilityDriverSteamMinT_Writer(String siteMtrlUtilityDriverSteamMinT)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityDriverSteamMinT))
                return;
        }

        /// <summary>
        /// Global number: 563
        /// API name: Steam DRIVERS-MIN. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Driver"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:t
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityDriverSteamMinT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 564
        /// API name: Steam HEATING-MAX. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityHeaterSteamMaxP"></param>
        public void SiteMtrlUtilityHeaterSteamMaxP_Writer(String siteMtrlUtilityHeaterSteamMaxP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityHeaterSteamMaxP))
                return;
        }

        /// <summary>
        /// Global number: 564
        /// API name: Steam HEATING-MAX. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityHeaterSteamMaxP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 565
        /// API name: Steam HEATING-MAX. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:t
        /// </summary>
        /// <param name="SiteMtrlUtilityHeaterSteamMaxT"></param>
        public void SiteMtrlUtilityHeaterSteamMaxT_Writer(String siteMtrlUtilityHeaterSteamMaxT)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityHeaterSteamMaxT))
                return;
        }

        /// <summary>
        /// Global number: 565
        /// API name: Steam HEATING-MAX. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:t
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityHeaterSteamMaxT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 566
        /// API name: Steam HEATING-MIN. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityHeaterSteamMinP"></param>
        public void SiteMtrlUtilityHeaterSteamMinP_Writer(String siteMtrlUtilityHeaterSteamMinP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityHeaterSteamMinP))
                return;
        }

        /// <summary>
        /// Global number: 566
        /// API name: Steam HEATING-MIN. PRESS.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityHeaterSteamMinP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 567
        /// API name: Steam HEATING-MIN. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:t
        /// </summary>
        /// <param name="SiteMtrlUtilityHeaterSteamMinT"></param>
        public void SiteMtrlUtilityHeaterSteamMinT_Writer(String siteMtrlUtilityHeaterSteamMinT)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityHeaterSteamMinT))
                return;
        }

        /// <summary>
        /// Global number: 567
        /// API name: Steam HEATING-MIN. TEMP.
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Heater"][eq:materialUtilityServiceType="Steam"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:t
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityHeaterSteamMinT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 748
        /// API name: INSTRUMENT AIR PRESSURE-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Instrument"][eq:materialUtilityServiceType="Air"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityInstrumentAirMaxP"></param>
        public void SiteMtrlUtilityInstrumentAirMaxP_Writer(String siteMtrlUtilityInstrumentAirMaxP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityInstrumentAirMaxP))
                return;
        }

        /// <summary>
        /// Global number: 748
        /// API name: INSTRUMENT AIR PRESSURE-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Instrument"][eq:materialUtilityServiceType="Air"]/eq:materialUtilityCondition[etl:propertyType="Maximum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityInstrumentAirMaxP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 760
        /// API name: MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Instrument"][eq:materialUtilityServiceType="Air"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <param name="SiteMtrlUtilityInstrumentAirMinP"></param>
        public void SiteMtrlUtilityInstrumentAirMinP_Writer(String siteMtrlUtilityInstrumentAirMinP)
        {
            if (String.IsNullOrEmpty(siteMtrlUtilityInstrumentAirMinP))
                return;
        }

        /// <summary>
        /// Global number: 760
        /// API name: MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/eq:materialUtilityServiceProvided[eq:utilityDemandDeviceType="Instrument"][eq:materialUtilityServiceType="Air"]/eq:materialUtilityCondition[etl:propertyType="Minimum"]/eq:p[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String SiteMtrlUtilityInstrumentAirMinP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 539
        /// API name: SITE-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/objb:name
        /// </summary>
        /// <param name="SiteName"></param>
        public void SiteName_Writer(String siteName)
        {
            if (String.IsNullOrEmpty(siteName))
                return;
            eqRotDoc.site.SiteFacility sFacility = siteFacility();

            if (!sFacility.name.Exists)
            {
                sFacility.name.Append();
            }

            sFacility.name.First.Value = siteName;
        }

        /// <summary>
        /// Global number: 539
        /// API name: SITE-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/objb:name
        /// </summary>
        /// <returns></returns>
        public String SiteName_Reader()
        {
            eqRotDoc.site.SiteFacility sFacility = siteFacility();

            if (!sFacility.name.Exists)
            {
                return null;
            }

            return sFacility.name.First.Value;
        }

        /// <summary>
        /// Global number: 25
        /// API name: BAROMETER-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property[mtrl:context/etl:propertyType="Ambient"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <param name="SiteP"></param>
        public void SiteP_Writer(String siteP)
        {
            if (String.IsNullOrEmpty(siteP))
                return;
        }

        /// <summary>
        /// Global number: 25
        /// API name: BAROMETER-
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property[mtrl:context/etl:propertyType="Ambient"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <returns></returns>
        public String SiteP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 201
        /// API name: 0
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:electricalDivision
        /// </summary>
        /// <param name="SubSiteElectricalDivision"></param>
        public void SubSiteElectricalDivision_Writer(String subSiteElectricalDivision)
        {
            if (String.IsNullOrEmpty(subSiteElectricalDivision))
                return;
        }

        /// <summary>
        /// Global number: 201
        /// API name: 0
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:electricalDivision
        /// </summary>
        /// <returns></returns>
        public String SubSiteElectricalDivision_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 200
        /// API name: Electrical Area Classification
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:electricalGroup
        /// </summary>
        /// <param name="SubSiteElectricalGroup"></param>
        public void SubSiteElectricalGroup_Writer(String subSiteElectricalGroup)
        {
            if (String.IsNullOrEmpty(subSiteElectricalGroup))
                return;
        }

        /// <summary>
        /// Global number: 200
        /// API name: Electrical Area Classification
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:electricalGroup
        /// </summary>
        /// <returns></returns>
        public String SubSiteElectricalGroup_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1748
        /// API name: EXPLOSIVE ENVIRONMENT CLASSIFICATION
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:explosiveAtmosphereCode
        /// </summary>
        /// <param name="SubSiteExplosiveAtmosCode"></param>
        public void SubSiteExplosiveAtmosCode_Writer(String subSiteExplosiveAtmosCode)
        {
            if (String.IsNullOrEmpty(subSiteExplosiveAtmosCode))
                return;
        }

        /// <summary>
        /// Global number: 1748
        /// API name: EXPLOSIVE ENVIRONMENT CLASSIFICATION
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:explosiveAtmosphereCode
        /// </summary>
        /// <returns></returns>
        public String SubSiteExplosiveAtmosCode_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 316
        /// API name: RELATIVE HUMIDITY-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property/mtrl:context[mtrl:phaseReference="Selector1"][etl:propertyType="Maximum"]/../mtrl:relativeLiquidSaturationFraction[@referencePhase="Selector2"]
        /// </summary>
        /// <param name="SubSiteMaxRelHumidity"></param>
        public void SubSiteMaxRelHumidity_Writer(String subSiteMaxRelHumidity)
        {
            if (String.IsNullOrEmpty(subSiteMaxRelHumidity))
                return;
        }

        /// <summary>
        /// Global number: 316
        /// API name: RELATIVE HUMIDITY-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property/mtrl:context[mtrl:phaseReference="Selector1"][etl:propertyType="Maximum"]/../mtrl:relativeLiquidSaturationFraction[@referencePhase="Selector2"]
        /// </summary>
        /// <returns></returns>
        public String SubSiteMaxRelHumidity_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 343
        /// API name: RELATIVE HUMIDITY-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property/mtrl:context[mtrl:phaseReference="Selector1"][etl:propertyType="Minimum"]/../mtrl:relativeLiquidSaturationFraction[@referencePhase="Selector2"]
        /// </summary>
        /// <param name="SubSiteMinRelHumidity"></param>
        public void SubSiteMinRelHumidity_Writer(String subSiteMinRelHumidity)
        {
            if (String.IsNullOrEmpty(subSiteMinRelHumidity))
                return;
        }

        /// <summary>
        /// Global number: 343
        /// API name: RELATIVE HUMIDITY-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property/mtrl:context[mtrl:phaseReference="Selector1"][etl:propertyType="Minimum"]/../mtrl:relativeLiquidSaturationFraction[@referencePhase="Selector2"]
        /// </summary>
        /// <returns></returns>
        public String SubSiteMinRelHumidity_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 655
        /// API name: Site_HeatedUnheated
        /// boolean(/eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:characteristic[site:operatingEnvironment="Heated"])
        /// </summary>
        /// <param name="SubSiteStdOperatingEnvironment"></param>
        public void SubSiteStdOperatingEnvironment_Writer(String subSiteStdOperatingEnvironment)
        {
            if (String.IsNullOrEmpty(subSiteStdOperatingEnvironment))
                return;
        }

        /// <summary>
        /// Global number: 655
        /// API name: Site_HeatedUnheated
        /// boolean(/eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:characteristic[site:operatingEnvironment="Heated"])
        /// </summary>
        /// <returns></returns>
        public String SubSiteStdOperatingEnvironment_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 313
        /// API name: RANGE OF AMBIENT TEMPS: -MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property[mtrl:context/etl:propertyType="Ambient"][mtrl:context/etl:propertyType="Maximum"]/mtrl:t
        /// </summary>
        /// <param name="SubSiteTAmbientMax"></param>
        public void SubSiteTAmbientMax_Writer(String subSiteTAmbientMax)
        {
            if (String.IsNullOrEmpty(subSiteTAmbientMax))
                return;
        }

        /// <summary>
        /// Global number: 313
        /// API name: RANGE OF AMBIENT TEMPS: -MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property[mtrl:context/etl:propertyType="Ambient"][mtrl:context/etl:propertyType="Maximum"]/mtrl:t
        /// </summary>
        /// <returns></returns>
        public String SubSiteTAmbientMax_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 340
        /// API name: RANGE OF AMBIENT TEMPS-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property[mtrl:context/etl:propertyType="Ambient"][mtrl:context/etl:propertyType="Minimum"]/mtrl:t
        /// </summary>
        /// <param name="SubSiteTAmbientMin"></param>
        public void SubSiteTAmbientMin_Writer(String subSiteTAmbientMin)
        {
            if (String.IsNullOrEmpty(subSiteTAmbientMin))
                return;
        }

        /// <summary>
        /// Global number: 340
        /// API name: RANGE OF AMBIENT TEMPS-MIN
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/mtrl:environmentalProperty/mtrl:property[mtrl:context/etl:propertyType="Ambient"][mtrl:context/etl:propertyType="Minimum"]/mtrl:t
        /// </summary>
        /// <returns></returns>
        public String SubSiteTAmbientMin_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1749
        /// API name: TEMPERATURE CLASSIFICATION
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:temperatureCode
        /// </summary>
        /// <param name="SubSiteTCode"></param>
        public void SubSiteTCode_Writer(String subSiteTCode)
        {
            if (String.IsNullOrEmpty(subSiteTCode))
                return;
        }

        /// <summary>
        /// Global number: 1749
        /// API name: TEMPERATURE CLASSIFICATION
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:siteSubArea/site:electricalAreaClassification/etl:temperatureCode
        /// </summary>
        /// <returns></returns>
        public String SubSiteTCode_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 323
        /// API name: SuctionPressure-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <param name="SuctionPMax"></param>
        public void SuctionPMax_Writer(String suctionPMax)
        {
            if (String.IsNullOrEmpty(suctionPMax))
                return;
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);
            if (!prop.p.Exists)
            {
                prop.p.Append().basis.Value = "absolute";
            }
            prop.p.First.Value = suctionPMax;
        }

        /// <summary>
        /// Global number: 323
        /// API name: SuctionPressure-MAX
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <returns></returns>
        public String SuctionPMax_Reader()
        {
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);
            if (!prop.p.Exists)
            {
                return null;
            }
            return prop.p.First.Value;
        }

        /// <summary>
        /// Global number: 576
        /// API name: SUCTION PRESS.   -Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <param name="SuctionPMin"></param>
        public void SuctionPMin_Writer(String suctionPMin)
        {
            if (String.IsNullOrEmpty(suctionPMin))
                return;
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);
            if (!prop.p.Exists)
            {
                prop.p.Append().basis.Value = "absolute";
            }
            prop.p.First.Value = suctionPMin;
        }

        /// <summary>
        /// Global number: 576
        /// API name: SUCTION PRESS.   -Min.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <returns></returns>
        public String SuctionPMin_Reader()
        {
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);
            if (!prop.p.Exists)
            {
                return null;
            }
            return prop.p.First.Value;
        }

        /// <summary>
        /// Global number: 577
        /// API name: SUCTION PRESS.   -NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <param name="SuctionPNormal"></param>
        public void SuctionPNormal_Writer(String suctionPNormal)
        {
            if (String.IsNullOrEmpty(suctionPNormal))
                return;
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);
            if (!prop.p.Exists)
            {
                prop.p.Append().basis.Value = "absolute";
            }
            prop.p.First.Value = suctionPNormal;
        }

        /// <summary>
        /// Global number: 577
        /// API name: SUCTION PRESS.   -NORMAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <returns></returns>
        public String SuctionPNormal_Reader()
        {
            eqRotDoc.mtrl.propertyType2 prop = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);
            if (!prop.p.Exists)
            {
                return null;
            }
            return prop.p.First.Value;
        }

        /// <summary>
        /// Global number: 482
        /// API name: SuctionPressure-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Flowrate, Rated"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <param name="SuctionPRated"></param>
        public void SuctionPRated_Writer(String suctionPRated)
        {
            if (String.IsNullOrEmpty(suctionPRated))
                return;
        }

        /// <summary>
        /// Global number: 482
        /// API name: SuctionPressure-RATED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Flowrate, Rated"]/mtrl:p[@basis="absolute"]
        /// </summary>
        /// <returns></returns>
        public String SuctionPRated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 626
        /// API name: TROPICALIZATION REQ'D.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:severeClimateProtection/eq:needEquipmentTropicalization
        /// </summary>
        /// <param name="TropicalizationReq"></param>
        public void TropicalizationReq_Writer(String tropicalizationReq)
        {
            if (String.IsNullOrEmpty(tropicalizationReq))
                return;
        }

        /// <summary>
        /// Global number: 626
        /// API name: TROPICALIZATION REQ'D.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:severeClimateProtection/eq:needEquipmentTropicalization
        /// </summary>
        /// <returns></returns>
        public String TropicalizationReq_Reader()
        {
            return null;
        } 
        #endregion

        #region Page 3
        /// <summary>
        /// Global number: 6
        /// API name: LONGITUDINAL DRIVER POSITIONING SCREWS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:levelingAndAdjustment[eqRot:screwUsage="Alignment"][eq:orientation="Unspecified"]/eqRot:isRequired
        /// </summary>
        /// <param name="BaseplateAlignScrewRequired"></param>
        public void BaseplateAlignScrewRequired_Writer(String baseplateAlignScrewRequired)
        {
            if (String.IsNullOrEmpty(baseplateAlignScrewRequired))
                return;

            eqRotDoc.eqRot.levelingAndAdjustmentType levelingAjustment = LevelingAndAdjustmentWith_OrientationAndScrewUsage(eqRotDoc.eq.EOrientation.EnumValues.eUnspecified, eqRotDoc.eqRot.EScrewUsage.EnumValues.eAlignment);
            if (!levelingAjustment.isRequired.Exists)
            {
                levelingAjustment.isRequired.Append();
            }

            levelingAjustment.isRequired.First.Value = baseplateAlignScrewRequired;
            
        }

        /// <summary>
        /// Global number: 6
        /// API name: LONGITUDINAL DRIVER POSITIONING SCREWS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:levelingAndAdjustment[eqRot:screwUsage="Alignment"][eq:orientation="Unspecified"]/eqRot:isRequired
        /// </summary>
        /// <returns></returns>
        public String BaseplateAlignScrewRequired_Reader()
        {
            
            eqRotDoc.eqRot.levelingAndAdjustmentType levelingAndAdj = LevelingAndAdjustmentWith_OrientationAndScrewUsage(eqRotDoc.eq.EOrientation.EnumValues.eUnspecified,eqRotDoc.eqRot.EScrewUsage.EnumValues.eAlignment);

            if (!levelingAndAdj.isRequired.Exists)
                return String.Empty;
            else
                return levelingAndAdj.isRequired.First.Value;

        }

        /// <summary>
        /// Global number: 28
        /// API name: API BASEPLATE NUMBER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:applicableStandard/eqRot:baseplateNumber
        /// </summary>
        /// <param name="BaseplateAPINumber"></param>
        public void BaseplateAPINumber_Writer(String baseplateAPINumber)
        {
            if (String.IsNullOrEmpty(baseplateAPINumber))
                return;
            eqRotDoc.eqRot.applicableStandardType2 applicablestandard = ApplicableStandard_Baseplate();
            if (!applicablestandard.baseplateNumber.Exists)
            {
                applicablestandard.baseplateNumber.Append();
            }
            applicablestandard.baseplateNumber.First.Value = baseplateAPINumber;   
        }

        /// <summary>
        /// Global number: 28
        /// API name: API BASEPLATE NUMBER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:applicableStandard/eqRot:baseplateNumber
        /// </summary>
        /// <returns></returns>
        public String BaseplateAPINumber_Reader()
        {
            eqRotDoc.eqRot.applicableStandardType2 applicableStandard = ApplicableStandard_Baseplate();
            if (applicableStandard.baseplateNumber.Exists)
            {
                return applicableStandard.baseplateNumber.First.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Global number: 709
        /// API name: Baseplate Drainage
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:draining/eqRot:baseplateDrain
        /// </summary>
        /// <param name="BaseplateDrain"></param>
        public void BaseplateDrain_Writer(String baseplateDrain)
        {
            if (String.IsNullOrEmpty(baseplateDrain))
                return;
            eqRotDoc.eqRot.drainingType draining = Draining();

            if (!draining.baseplateDrain.Exists)
            {
                draining.baseplateDrain.Append().Value = baseplateDrain;
                return;
            }
            draining.baseplateDrain.First.Value = baseplateDrain;
        }

        /// <summary>
        /// Global number: 709
        /// API name: Baseplate Drainage
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:draining/eqRot:baseplateDrain
        /// </summary>
        /// <returns></returns>
        public String BaseplateDrain_Reader()
        {
            eqRotDoc.eqRot.drainingType draining = Draining();

            if (!draining.baseplateDrain.Exists)
                return String.Empty;

            return draining.baseplateDrain.First.Value;
        }

        /// <summary>
        /// Global number: 33
        /// API name: DRAIN CONNECTION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:draining[eqRot:baseplateDrain="Drain connection"]/eqRot:isPresent
        /// </summary>
        /// <param name="BaseplateDrainConnectionRequired"></param>
        public void BaseplateDrainConnectionRequired_Writer(String baseplateDrainConnectionRequired)
        {
            if (String.IsNullOrEmpty(baseplateDrainConnectionRequired))
                return;
        }

        /// <summary>
        /// Global number: 33
        /// API name: DRAIN CONNECTION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:draining[eqRot:baseplateDrain="Drain connection"]/eqRot:isPresent
        /// </summary>
        /// <returns></returns>
        public String BaseplateDrainConnectionRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 733
        /// API name: DRAIN TO SKID EDGE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:draining/eqRot:isDrainToSkidEdge
        /// </summary>
        /// <param name="BaseplateDrainToSkidEdge"></param>
        public void BaseplateDrainToSkidEdge_Writer(String baseplateDrainToSkidEdge)
        {
            if (String.IsNullOrEmpty(baseplateDrainToSkidEdge))
                return;
        }

        /// <summary>
        /// Global number: 733
        /// API name: DRAIN TO SKID EDGE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:draining/eqRot:isDrainToSkidEdge
        /// </summary>
        /// <returns></returns>
        public String BaseplateDrainToSkidEdge_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 844
        /// API name: SUPPLIED WITH :-GROUT AND VENT HOLES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:hasGroutAndVentHole
        /// </summary>
        /// <param name="BaseplateGroutVentHole"></param>
        public void BaseplateGroutVentHole_Writer(String baseplateGroutVentHole)
        {
            if (String.IsNullOrEmpty(baseplateGroutVentHole))
                return;
        }

        /// <summary>
        /// Global number: 844
        /// API name: SUPPLIED WITH :-GROUT AND VENT HOLES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:hasGroutAndVentHole
        /// </summary>
        /// <returns></returns>
        public String BaseplateGroutVentHole_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 30
        /// API name: MOUNTING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:baseplateMountingType
        /// </summary>
        /// <param name="BaseplateMountingType"></param>
        public void BaseplateMountingType_Writer(String baseplateMountingType)
        {
            if (String.IsNullOrEmpty(baseplateMountingType))
                return;
        }

        /// <summary>
        /// Global number: 30
        /// API name: MOUNTING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:baseplateMountingType
        /// </summary>
        /// <returns></returns>
        public String BaseplateMountingType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 769
        /// API name: MOUNTING PADS TO BE MACHINED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:padMachiningRequired
        /// </summary>
        /// <param name="BaseplateMountPadMachiningRequired"></param>
        public void BaseplateMountPadMachiningRequired_Writer(String baseplateMountPadMachiningRequired)
        {
            if (String.IsNullOrEmpty(baseplateMountPadMachiningRequired))
                return;
        }

        /// <summary>
        /// Global number: 769
        /// API name: MOUNTING PADS TO BE MACHINED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:padMachiningRequired
        /// </summary>
        /// <returns></returns>
        public String BaseplateMountPadMachiningRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 768
        /// API name: MOUNTING PADS SIZED FOR BASEPLATE LEVELING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:padSizingForLevelingRequired
        /// </summary>
        /// <param name="BaseplateMountPadSizingRequired"></param>
        public void BaseplateMountPadSizingRequired_Writer(String baseplateMountPadSizingRequired)
        {
            if (String.IsNullOrEmpty(baseplateMountPadSizingRequired))
                return;
        }

        /// <summary>
        /// Global number: 768
        /// API name: MOUNTING PADS SIZED FOR BASEPLATE LEVELING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:padSizingForLevelingRequired
        /// </summary>
        /// <returns></returns>
        public String BaseplateMountPadSizingRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 31
        /// API name: Baseplate-NonGrout-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:isNonGroutConstruction
        /// </summary>
        /// <param name="BaseplateNonGrout"></param>
        public void BaseplateNonGrout_Writer(String baseplateNonGrout)
        {
            if (String.IsNullOrEmpty(baseplateNonGrout))
                return;
        }

        /// <summary>
        /// Global number: 31
        /// API name: Baseplate-NonGrout-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:isNonGroutConstruction
        /// </summary>
        /// <returns></returns>
        public String BaseplateNonGrout_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 32
        /// API name: OTHER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/obj:remark
        /// </summary>
        /// <param name="BaseplateRemark_BaseplateGroutRemark"></param>
        public void BaseplateRemark_BaseplateGroutRemark_Writer(String baseplateRemark_BaseplateGroutRemark)
        {
            if (String.IsNullOrEmpty(baseplateRemark_BaseplateGroutRemark))
                return;
        }

        /// <summary>
        /// Global number: 32
        /// API name: OTHER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/obj:remark
        /// </summary>
        /// <returns></returns>
        public String BaseplateRemark_BaseplateGroutRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 807
        /// API name: PROVIDE SPACER PLATE UNDER ALL EQUIPMENT FEET
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:spacerPlateUnderFeetProvided
        /// </summary>
        /// <param name="BaseplateSpacerPlateUnderFeetProvided"></param>
        public void BaseplateSpacerPlateUnderFeetProvided_Writer(String baseplateSpacerPlateUnderFeetProvided)
        {
            if (String.IsNullOrEmpty(baseplateSpacerPlateUnderFeetProvided))
                return;
        }

        /// <summary>
        /// Global number: 807
        /// API name: PROVIDE SPACER PLATE UNDER ALL EQUIPMENT FEET
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:spacerPlateUnderFeetProvided
        /// </summary>
        /// <returns></returns>
        public String BaseplateSpacerPlateUnderFeetProvided_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 708
        /// API name: BASEPLATE CONSTRUCTION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:baseplateType
        /// </summary>
        /// <param name="BaseplateType"></param>
        public void BaseplateType_Writer(String baseplateType)
        {
            if (String.IsNullOrEmpty(baseplateType))
                return;
        }

        /// <summary>
        /// Global number: 708
        /// API name: BASEPLATE CONSTRUCTION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:baseplateType
        /// </summary>
        /// <returns></returns>
        public String BaseplateType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 861
        /// API name: VERTICAL LEVELING SCREWS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:levelingAndAdjustment[eqRot:screwUsage="Leveling"][eq:orientation="Vertical"]/eqRot:isRequired
        /// </summary>
        /// <param name="BaseplateVerticalLevelingScrewRequired"></param>
        public void BaseplateVerticalLevelingScrewRequired_Writer(String baseplateVerticalLevelingScrewRequired)
        {
            if (String.IsNullOrEmpty(baseplateVerticalLevelingScrewRequired))
                return;
        }

        /// <summary>
        /// Global number: 861
        /// API name: VERTICAL LEVELING SCREWS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:mounting/eqRot:levelingAndAdjustment[eqRot:screwUsage="Leveling"][eq:orientation="Vertical"]/eqRot:isRequired
        /// </summary>
        /// <returns></returns>
        public String BaseplateVerticalLevelingScrewRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 85
        /// API name: CONSTANT LEVEL OILER PREFERENCE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:constantLevelOiler/eq:typeDescription
        /// </summary>
        /// <param name="BearingLubeConstantLevelOilDesc"></param>
        public void BearingLubeConstantLevelOilDesc_Writer(String bearingLubeConstantLevelOilDesc)
        {
            if (String.IsNullOrEmpty(bearingLubeConstantLevelOilDesc))
                return;
        }

        /// <summary>
        /// Global number: 85
        /// API name: CONSTANT LEVEL OILER PREFERENCE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:constantLevelOiler/eq:typeDescription
        /// </summary>
        /// <returns></returns>
        public String BearingLubeConstantLevelOilDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 395
        /// API name: OIL VISC. ISO GRADE VG-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:oilISOViscosityGrade
        /// </summary>
        /// <param name="BearingLubeOilISOViscosityGrade"></param>
        public void BearingLubeOilISOViscosityGrade_Writer(String bearingLubeOilISOViscosityGrade)
        {
            if (String.IsNullOrEmpty(bearingLubeOilISOViscosityGrade))
                return;
        }

        /// <summary>
        /// Global number: 395
        /// API name: OIL VISC. ISO GRADE VG-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:oilISOViscosityGrade
        /// </summary>
        /// <returns></returns>
        public String BearingLubeOilISOViscosityGrade_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 438
        /// API name: PRESSURE LUBE TO ISO 1043-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:lubeSystemStandard
        /// </summary>
        /// <param name="BearingLubePSystemStandard"></param>
        public void BearingLubePSystemStandard_Writer(String bearingLubePSystemStandard)
        {
            if (String.IsNullOrEmpty(bearingLubePSystemStandard))
                return;
        }

        /// <summary>
        /// Global number: 438
        /// API name: PRESSURE LUBE TO ISO 1043-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:lubeSystemStandard
        /// </summary>
        /// <returns></returns>
        public String BearingLubePSystemStandard_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 42
        /// API name: LUBRICATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:lubeSystemType
        /// </summary>
        /// <param name="BearingLubeSystemType"></param>
        public void BearingLubeSystemType_Writer(String bearingLubeSystemType)
        {
            if (String.IsNullOrEmpty(bearingLubeSystemType))
                return;
        }

        /// <summary>
        /// Global number: 42
        /// API name: LUBRICATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:lubeSystemType
        /// </summary>
        /// <returns></returns>
        public String BearingLubeSystemType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 755
        /// API name: Location of Pressurized Lube Oil System mounted on baseplate
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:mounting/eq:locationDescription
        /// </summary>
        /// <param name="BearingPLubeLocationDescription"></param>
        public void BearingPLubeLocationDescription_Writer(String bearingPLubeLocationDescription)
        {
            if (String.IsNullOrEmpty(bearingPLubeLocationDescription))
                return;
        }

        /// <summary>
        /// Global number: 755
        /// API name: Location of Pressurized Lube Oil System mounted on baseplate
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:mounting/eq:locationDescription
        /// </summary>
        /// <returns></returns>
        public String BearingPLubeLocationDescription_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 804
        /// API name: Pressurized Lube Oil System mounted on same baseplate as pump
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:mounting/eq:isMountedOnCommonBaseplate
        /// </summary>
        /// <param name="BearingPLubeOnCommonBaseplate"></param>
        public void BearingPLubeOnCommonBaseplate_Writer(String bearingPLubeOnCommonBaseplate)
        {
            if (String.IsNullOrEmpty(bearingPLubeOnCommonBaseplate))
                return;
        }

        /// <summary>
        /// Global number: 804
        /// API name: Pressurized Lube Oil System mounted on same baseplate as pump
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:mounting/eq:isMountedOnCommonBaseplate
        /// </summary>
        /// <returns></returns>
        public String BearingPLubeOnCommonBaseplate_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 750
        /// API name: INTERCONNECTING PIPING PROVIDED BY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:equipmentConnection/eq:endDescription/eq:endConnectionItem/eq:pipingProvidedBy
        /// </summary>
        /// <param name="BearingPLubePipingProvideBy"></param>
        public void BearingPLubePipingProvideBy_Writer(String bearingPLubePipingProvideBy)
        {
            if (String.IsNullOrEmpty(bearingPLubePipingProvideBy))
                return;
        }

        /// <summary>
        /// Global number: 750
        /// API name: INTERCONNECTING PIPING PROVIDED BY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:lubeSystem/eq:equipmentConnection/eq:endDescription/eq:endConnectionItem/eq:pipingProvidedBy
        /// </summary>
        /// <returns></returns>
        public String BearingPLubePipingProvideBy_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 617
        /// API name: REVIEW AND APPROVE THRUST BEARING SIZE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly[eq:bearingDetail/eq:bearingType="ThrustBearing"]/eq:needSizeApproval
        /// </summary>
        /// <param name="BearingThrustNeedSizeApproval"></param>
        public void BearingThrustNeedSizeApproval_Writer(String bearingThrustNeedSizeApproval)
        {
            if (String.IsNullOrEmpty(bearingThrustNeedSizeApproval))
                return;
        }

        /// <summary>
        /// Global number: 617
        /// API name: REVIEW AND APPROVE THRUST BEARING SIZE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly[eq:bearingDetail/eq:bearingType="ThrustBearing"]/eq:needSizeApproval
        /// </summary>
        /// <returns></returns>
        public String BearingThrustNeedSizeApproval_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 668
        /// API name: BARREL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing[eqRot:casingType="Barrel"]/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="CasingBarrelMaterialName"></param>
        public void CasingBarrelMaterialName_Writer(String casingBarrelMaterialName)
        {
            if (String.IsNullOrEmpty(casingBarrelMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 668
        /// API name: BARREL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing[eqRot:casingType="Barrel"]/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String CasingBarrelMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 64
        /// API name: CASE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="CasingMaterialName"></param>
        public void CasingMaterialName_Writer(String casingMaterialName)
        {
            if (String.IsNullOrEmpty(casingMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 64
        /// API name: CASE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String CasingMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 65
        /// API name: CASE WEAR RING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:wearRing/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="CasingRingMaterialName"></param>
        public void CasingRingMaterialName_Writer(String casingRingMaterialName)
        {
            if (String.IsNullOrEmpty(casingRingMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 65
        /// API name: CASE WEAR RING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:wearRing/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String CasingRingMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 735
        /// API name: DRAINS MANIFOLDED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Design specification"][eq:connectionType="Drain"]/eq:needSingleManifold
        /// </summary>
        /// <param name="ConnectionDrainDesignSingleManifold"></param>
        public void ConnectionDrainDesignSingleManifold_Writer(String connectionDrainDesignSingleManifold)
        {
            if (String.IsNullOrEmpty(connectionDrainDesignSingleManifold))
                return;
        }

        /// <summary>
        /// Global number: 735
        /// API name: DRAINS MANIFOLDED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Design specification"][eq:connectionType="Drain"]/eq:needSingleManifold
        /// </summary>
        /// <returns></returns>
        public String ConnectionDrainDesignSingleManifold_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 860
        /// API name: VENTS MANIFOLDED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Design specification"][eq:connectionType="Vent"]/eq:needSingleManifold
        /// </summary>
        /// <param name="ConnectionVentDesignSingleManifold"></param>
        public void ConnectionVentDesignSingleManifold_Writer(String connectionVentDesignSingleManifold)
        {
            if (String.IsNullOrEmpty(connectionVentDesignSingleManifold))
                return;
        }

        /// <summary>
        /// Global number: 860
        /// API name: VENTS MANIFOLDED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Design specification"][eq:connectionType="Vent"]/eq:needSingleManifold
        /// </summary>
        /// <returns></returns>
        public String ConnectionVentDesignSingleManifold_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 141
        /// API name: DIFFUSERS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:diffuser/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="DiffuserMaterialName"></param>
        public void DiffuserMaterialName_Writer(String diffuserMaterialName)
        {
            if (String.IsNullOrEmpty(diffuserMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 141
        /// API name: DIFFUSERS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:diffuser/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String DiffuserMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 268
        /// API name: IMPELLER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="ImpellerMaterialName"></param>
        public void ImpellerMaterialName_Writer(String impellerMaterialName)
        {
            if (String.IsNullOrEmpty(impellerMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 268
        /// API name: IMPELLER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String ImpellerMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 269
        /// API name: IMPELLER WEAR RING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/eqRot:wearRing/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="ImpellerRingMaterialName"></param>
        public void ImpellerRingMaterialName_Writer(String impellerRingMaterialName)
        {
            if (String.IsNullOrEmpty(impellerRingMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 269
        /// API name: IMPELLER WEAR RING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/eqRot:wearRing/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String ImpellerRingMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 580
        /// API name: SUCTION-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <param name="InletConnectionNPS"></param>
        public void InletConnectionNPS_Writer(String inletConnectionNPS)
        {
            if (String.IsNullOrEmpty(inletConnectionNPS))
                return;
        }

        /// <summary>
        /// Global number: 580
        /// API name: SUCTION-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String InletConnectionNPS_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 575
        /// API name: SUCTION-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:connectionPosition
        /// </summary>
        /// <param name="InletConnectionPosition"></param>
        public void InletConnectionPosition_Writer(String inletConnectionPosition)
        {
            if (String.IsNullOrEmpty(inletConnectionPosition))
                return;
        }

        /// <summary>
        /// Global number: 575
        /// API name: SUCTION-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String InletConnectionPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 578
        /// API name: SUCTION-FLANGE RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="InletConnectionRatingPClass_InletConnectionRatingPNumber"></param>
        public void InletConnectionRatingPClass_InletConnectionRatingPNumber_Writer(String inletConnectionRatingPClass_InletConnectionRatingPNumber)
        {
            if (String.IsNullOrEmpty(inletConnectionRatingPClass_InletConnectionRatingPNumber))
                return;
        }

        /// <summary>
        /// Global number: 578
        /// API name: SUCTION-FLANGE RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String InletConnectionRatingPClass_InletConnectionRatingPNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 573
        /// API name: SUCTION-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:endDescription/eq:flange/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="InletConnectionStyle"></param>
        public void InletConnectionStyle_Writer(String inletConnectionStyle)
        {
            if (String.IsNullOrEmpty(inletConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 573
        /// API name: SUCTION-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Inlet"]/eq:endDescription/eq:flange/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String InletConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 110
        /// API name: COUPLING BALANCED TO ISO 1940-1 G6.3-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:needBalanceToISO1940
        /// </summary>
        /// <param name="MotorToPumpCouplingBalanceToISO1940"></param>
        public void MotorToPumpCouplingBalanceToISO1940_Writer(String motorToPumpCouplingBalanceToISO1940)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingBalanceToISO1940))
                return;
        }

        /// <summary>
        /// Global number: 110
        /// API name: COUPLING BALANCED TO ISO 1940-1 G6.3-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:needBalanceToISO1940
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingBalanceToISO1940_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 113
        /// API name: COUPLING GUARD STANDARD PER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:guard/eq:applicableStandard/eq:couplingGuardStandard
        /// </summary>
        /// <param name="MotorToPumpCouplingGuardStd"></param>
        public void MotorToPumpCouplingGuardStd_Writer(String motorToPumpCouplingGuardStd)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingGuardStd))
                return;
        }

        /// <summary>
        /// Global number: 113
        /// API name: COUPLING GUARD STANDARD PER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:guard/eq:applicableStandard/eq:couplingGuardStandard
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingGuardStd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 881
        /// API name: Window on Coupling Guard
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqElec:electricMotor/eq:coupling/eq:guard/eq:isWindowRequired
        /// </summary>
        /// <param name="MotorToPumpCouplingGuardWindowRequired"></param>
        public void MotorToPumpCouplingGuardWindowRequired_Writer(String motorToPumpCouplingGuardWindowRequired)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingGuardWindowRequired))
                return;
        }

        /// <summary>
        /// Global number: 881
        /// API name: Window on Coupling Guard
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqElec:electricMotor/eq:coupling/eq:guard/eq:isWindowRequired
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingGuardWindowRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 111
        /// API name: COUPLING WITH PROPRIETARY CLAMPING DEVICE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:hasProprietaryClamp
        /// </summary>
        /// <param name="MotorToPumpCouplingHasClamp"></param>
        public void MotorToPumpCouplingHasClamp_Writer(String motorToPumpCouplingHasClamp)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingHasClamp))
                return;
        }

        /// <summary>
        /// Global number: 111
        /// API name: COUPLING WITH PROPRIETARY CLAMPING DEVICE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:hasProprietaryClamp
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingHasClamp_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 114
        /// API name: COUPLING WITH HYDRAULIC FIT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver[eqRot:driverType="ElectricMotor"]/eqRot:driverItem/eq:coupling/eq:hasHydraulicFit
        /// </summary>
        /// <param name="MotorToPumpCouplingHasHydraulicFit"></param>
        public void MotorToPumpCouplingHasHydraulicFit_Writer(String motorToPumpCouplingHasHydraulicFit)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingHasHydraulicFit))
                return;
        }

        /// <summary>
        /// Global number: 114
        /// API name: COUPLING WITH HYDRAULIC FIT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver[eqRot:driverType="ElectricMotor"]/eqRot:driverItem/eq:coupling/eq:hasHydraulicFit
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingHasHydraulicFit_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 121
        /// API name: RIGID-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:isRigid
        /// </summary>
        /// <param name="MotorToPumpCouplingIsRigid"></param>
        public void MotorToPumpCouplingIsRigid_Writer(String motorToPumpCouplingIsRigid)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingIsRigid))
                return;
        }

        /// <summary>
        /// Global number: 121
        /// API name: RIGID-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:isRigid
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingIsRigid_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 117
        /// API name: MANUFACTURER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:id/ctx:manufacturerCompany/objb:name
        /// </summary>
        /// <param name="MotorToPumpCouplingManufacturer"></param>
        public void MotorToPumpCouplingManufacturer_Writer(String motorToPumpCouplingManufacturer)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingManufacturer))
                return;
        }

        /// <summary>
        /// Global number: 117
        /// API name: MANUFACTURER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:id/ctx:manufacturerCompany/objb:name
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingManufacturer_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 118
        /// API name: MODEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:id/eq:model
        /// </summary>
        /// <param name="MotorToPumpCouplingPartModel"></param>
        public void MotorToPumpCouplingPartModel_Writer(String motorToPumpCouplingPartModel)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingPartModel))
                return;
        }

        /// <summary>
        /// Global number: 118
        /// API name: MODEL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:id/eq:model
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingPartModel_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 120
        /// API name: RATING (POWER/100 RPM)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:rated100RPMTorque
        /// </summary>
        /// <param name="MotorToPumpCouplingRated100RPMTorque"></param>
        public void MotorToPumpCouplingRated100RPMTorque_Writer(String motorToPumpCouplingRated100RPMTorque)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingRated100RPMTorque))
                return;
        }

        /// <summary>
        /// Global number: 120
        /// API name: RATING (POWER/100 RPM)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:rated100RPMTorque
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingRated100RPMTorque_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 106
        /// API name: SERVICE FACTOR-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/etl:serviceCategory/etl:serviceFactor
        /// </summary>
        /// <param name="MotorToPumpCouplingServiceFactor"></param>
        public void MotorToPumpCouplingServiceFactor_Writer(String motorToPumpCouplingServiceFactor)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingServiceFactor))
                return;
        }

        /// <summary>
        /// Global number: 106
        /// API name: SERVICE FACTOR-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/etl:serviceCategory/etl:serviceFactor
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingServiceFactor_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 123
        /// API name: SPACER LENGTH-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:spacer/eq:spacerLength
        /// </summary>
        /// <param name="MotorToPumpCouplingSpacerLength"></param>
        public void MotorToPumpCouplingSpacerLength_Writer(String motorToPumpCouplingSpacerLength)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingSpacerLength))
                return;
        }

        /// <summary>
        /// Global number: 123
        /// API name: SPACER LENGTH-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:coupling/eq:spacer/eq:spacerLength
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingSpacerLength_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 657
        /// API name: COUPLING IN COMPLIANCE WITH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqElec:electricMotor/eq:coupling/eq:applicableStandard/eq:couplingStandard
        /// </summary>
        /// <param name="MotorToPumpCouplingStandard"></param>
        public void MotorToPumpCouplingStandard_Writer(String motorToPumpCouplingStandard)
        {
            if (String.IsNullOrEmpty(motorToPumpCouplingStandard))
                return;
        }

        /// <summary>
        /// Global number: 657
        /// API name: COUPLING IN COMPLIANCE WITH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/eqElec:electricMotor/eq:coupling/eq:applicableStandard/eq:couplingStandard
        /// </summary>
        /// <returns></returns>
        public String MotorToPumpCouplingStandard_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 146
        /// API name: DISCHARGE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:connectionPosition
        /// </summary>
        /// <param name="OutletConnectionPosition"></param>
        public void OutletConnectionPosition_Writer(String outletConnectionPosition)
        {
            if (String.IsNullOrEmpty(outletConnectionPosition))
                return;
        }

        /// <summary>
        /// Global number: 146
        /// API name: DISCHARGE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String OutletConnectionPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 152
        /// API name: DISCHARGE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:endDescription/eq:flange/eq:nominalPipeSize
        /// </summary>
        /// <param name="OutletFlangeConnectionNPS"></param>
        public void OutletFlangeConnectionNPS_Writer(String outletFlangeConnectionNPS)
        {
            if (String.IsNullOrEmpty(outletFlangeConnectionNPS))
                return;
        }

        /// <summary>
        /// Global number: 152
        /// API name: DISCHARGE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:endDescription/eq:flange/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String OutletFlangeConnectionNPS_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 151
        /// API name: DISCHARGE-FLANGE RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:endDescription/eq:flange/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="OutletFlangeConnectionRatingPClass_OutletFlangeConnectionRatingPNumber"></param>
        public void OutletFlangeConnectionRatingPClass_OutletFlangeConnectionRatingPNumber_Writer(String outletFlangeConnectionRatingPClass_OutletFlangeConnectionRatingPNumber)
        {
            if (String.IsNullOrEmpty(outletFlangeConnectionRatingPClass_OutletFlangeConnectionRatingPNumber))
                return;
        }

        /// <summary>
        /// Global number: 151
        /// API name: DISCHARGE-FLANGE RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:endDescription/eq:flange/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String OutletFlangeConnectionRatingPClass_OutletFlangeConnectionRatingPNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 143
        /// API name: DISCHARGE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:endDescription/eq:flange/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="OutletFlangeConnectionStyle"></param>
        public void OutletFlangeConnectionStyle_Writer(String outletFlangeConnectionStyle)
        {
            if (String.IsNullOrEmpty(outletFlangeConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 143
        /// API name: DISCHARGE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[eq:connectionType="Outlet"]/eq:endDescription/eq:flange/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String OutletFlangeConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 705
        /// API name: BALANCE/LEAK-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="PressureCasingBalanceLeakoffFlangeConnectionStyle"></param>
        public void PressureCasingBalanceLeakoffFlangeConnectionStyle_Writer(String pressureCasingBalanceLeakoffFlangeConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingBalanceLeakoffFlangeConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 705
        /// API name: BALANCE/LEAK-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingBalanceLeakoffFlangeConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 23
        /// API name: BALANCE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <param name="PressureCasingBalanceLeakoffNPS"></param>
        public void PressureCasingBalanceLeakoffNPS_Writer(String pressureCasingBalanceLeakoffNPS)
        {
            if (String.IsNullOrEmpty(pressureCasingBalanceLeakoffNPS))
                return;
        }

        /// <summary>
        /// Global number: 23
        /// API name: BALANCE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String PressureCasingBalanceLeakoffNPS_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 22
        /// API name: BALANCE / LEAK OFF-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:numberAtPosition
        /// </summary>
        /// <param name="PressureCasingBalanceLeakoffNumber"></param>
        public void PressureCasingBalanceLeakoffNumber_Writer(String pressureCasingBalanceLeakoffNumber)
        {
            if (String.IsNullOrEmpty(pressureCasingBalanceLeakoffNumber))
                return;
        }

        /// <summary>
        /// Global number: 22
        /// API name: BALANCE / LEAK OFF-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:numberAtPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingBalanceLeakoffNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 706
        /// API name: BALANCE/LEAK-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:connectionPosition
        /// </summary>
        /// <param name="PressureCasingBalanceLeakoffPosition"></param>
        public void PressureCasingBalanceLeakoffPosition_Writer(String pressureCasingBalanceLeakoffPosition)
        {
            if (String.IsNullOrEmpty(pressureCasingBalanceLeakoffPosition))
                return;
        }

        /// <summary>
        /// Global number: 706
        /// API name: BALANCE/LEAK-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingBalanceLeakoffPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 707
        /// API name: BALANCE/LEAK-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="PressureCasingBalanceLeakoffPRating"></param>
        public void PressureCasingBalanceLeakoffPRating_Writer(String pressureCasingBalanceLeakoffPRating)
        {
            if (String.IsNullOrEmpty(pressureCasingBalanceLeakoffPRating))
                return;
        }

        /// <summary>
        /// Global number: 707
        /// API name: BALANCE/LEAK-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String PressureCasingBalanceLeakoffPRating_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 24
        /// API name: BALANCE-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <param name="PressureCasingBalanceLeakoffWeldConnectionStyle"></param>
        public void PressureCasingBalanceLeakoffWeldConnectionStyle_Writer(String pressureCasingBalanceLeakoffWeldConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingBalanceLeakoffWeldConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 24
        /// API name: BALANCE-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Balance-leakoff"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingBalanceLeakoffWeldConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 854
        /// API name: THREADED CONNECTIONS FOR PIPELINE SERVICE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureCasing/eq:equipmentConnection/eq:mayUseThreaded
        /// </summary>
        /// <param name="PressureCasingConnMayUseThreaded"></param>
        public void PressureCasingConnMayUseThreaded_Writer(String pressureCasingConnMayUseThreaded)
        {
            if (String.IsNullOrEmpty(pressureCasingConnMayUseThreaded))
                return;
        }

        /// <summary>
        /// Global number: 854
        /// API name: THREADED CONNECTIONS FOR PIPELINE SERVICE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureCasing/eq:equipmentConnection/eq:mayUseThreaded
        /// </summary>
        /// <returns></returns>
        public String PressureCasingConnMayUseThreaded_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 826
        /// API name: SPECIAL FITTINGS FOR TRANSITIONING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureCasing/eq:equipmentConnection/eq:mayUseThreadedFittingForTransitioning
        /// </summary>
        /// <param name="PressureCasingConnMayUseThreadedForTrans"></param>
        public void PressureCasingConnMayUseThreadedForTrans_Writer(String pressureCasingConnMayUseThreadedForTrans)
        {
            if (String.IsNullOrEmpty(pressureCasingConnMayUseThreadedForTrans))
                return;
        }

        /// <summary>
        /// Global number: 826
        /// API name: SPECIAL FITTINGS FOR TRANSITIONING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureCasing/eq:equipmentConnection/eq:mayUseThreadedFittingForTransitioning
        /// </summary>
        /// <returns></returns>
        public String PressureCasingConnMayUseThreadedForTrans_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 736
        /// API name: DRAINS-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="PressureCasingDrainFlangeConnectionStyle"></param>
        public void PressureCasingDrainFlangeConnectionStyle_Writer(String pressureCasingDrainFlangeConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingDrainFlangeConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 736
        /// API name: DRAINS-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingDrainFlangeConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 439
        /// API name: DRAIN-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:numberAtPosition
        /// </summary>
        /// <param name="PressureCasingDrainNumber"></param>
        public void PressureCasingDrainNumber_Writer(String pressureCasingDrainNumber)
        {
            if (String.IsNullOrEmpty(pressureCasingDrainNumber))
                return;
        }

        /// <summary>
        /// Global number: 439
        /// API name: DRAIN-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:numberAtPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingDrainNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 737
        /// API name: DRAINS-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:connectionPosition
        /// </summary>
        /// <param name="PressureCasingDrainPosition"></param>
        public void PressureCasingDrainPosition_Writer(String pressureCasingDrainPosition)
        {
            if (String.IsNullOrEmpty(pressureCasingDrainPosition))
                return;
        }

        /// <summary>
        /// Global number: 737
        /// API name: DRAINS-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingDrainPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 738
        /// API name: DRAINS-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="PressureCasingDrainPRating"></param>
        public void PressureCasingDrainPRating_Writer(String pressureCasingDrainPRating)
        {
            if (String.IsNullOrEmpty(pressureCasingDrainPRating))
                return;
        }

        /// <summary>
        /// Global number: 738
        /// API name: DRAINS-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String PressureCasingDrainPRating_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 153
        /// API name: DRAIN-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <param name="PressureCasingDrainSize"></param>
        public void PressureCasingDrainSize_Writer(String pressureCasingDrainSize)
        {
            if (String.IsNullOrEmpty(pressureCasingDrainSize))
                return;
        }

        /// <summary>
        /// Global number: 153
        /// API name: DRAIN-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String PressureCasingDrainSize_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 734
        /// API name: Drain Valve Supplied By
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:bleedValveSuppliedBy
        /// </summary>
        /// <param name="PressureCasingDrainVlvSupplier"></param>
        public void PressureCasingDrainVlvSupplier_Writer(String pressureCasingDrainVlvSupplier)
        {
            if (String.IsNullOrEmpty(pressureCasingDrainVlvSupplier))
                return;
        }

        /// <summary>
        /// Global number: 734
        /// API name: Drain Valve Supplied By
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:bleedValveSuppliedBy
        /// </summary>
        /// <returns></returns>
        public String PressureCasingDrainVlvSupplier_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 154
        /// API name: DRAIN-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <param name="PressureCasingDrainWeldConnectionStyle"></param>
        public void PressureCasingDrainWeldConnectionStyle_Writer(String pressureCasingDrainWeldConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingDrainWeldConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 154
        /// API name: DRAIN-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingDrainWeldConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 799
        /// API name: PRESSURE GAUGE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="PressureCasingGaugePFlangeConnectionStyle"></param>
        public void PressureCasingGaugePFlangeConnectionStyle_Writer(String pressureCasingGaugePFlangeConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugePFlangeConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 799
        /// API name: PRESSURE GAUGE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugePFlangeConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 437
        /// API name: PRESSURE GAUGE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <param name="PressureCasingGaugePNPS"></param>
        public void PressureCasingGaugePNPS_Writer(String pressureCasingGaugePNPS)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugePNPS))
                return;
        }

        /// <summary>
        /// Global number: 437
        /// API name: PRESSURE GAUGE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugePNPS_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 436
        /// API name: PRESSURE GAUGE-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:numberAtPosition
        /// </summary>
        /// <param name="PressureCasingGaugePNumber"></param>
        public void PressureCasingGaugePNumber_Writer(String pressureCasingGaugePNumber)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugePNumber))
                return;
        }

        /// <summary>
        /// Global number: 436
        /// API name: PRESSURE GAUGE-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:numberAtPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugePNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 800
        /// API name: PRESSURE GAUGE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:connectionPosition
        /// </summary>
        /// <param name="PressureCasingGaugePPosition"></param>
        public void PressureCasingGaugePPosition_Writer(String pressureCasingGaugePPosition)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugePPosition))
                return;
        }

        /// <summary>
        /// Global number: 800
        /// API name: PRESSURE GAUGE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugePPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 801
        /// API name: PRESSURE GAUGE-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="PressureCasingGaugePPRating"></param>
        public void PressureCasingGaugePPRating_Writer(String pressureCasingGaugePPRating)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugePPRating))
                return;
        }

        /// <summary>
        /// Global number: 801
        /// API name: PRESSURE GAUGE-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugePPRating_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 440
        /// API name: PRESSURE GAUGE-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <param name="PressureCasingGaugePWeldConnectionStyle"></param>
        public void PressureCasingGaugePWeldConnectionStyle_Writer(String pressureCasingGaugePWeldConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugePWeldConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 440
        /// API name: PRESSURE GAUGE-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-P"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugePWeldConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 846
        /// API name: TEMP GAGE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="PressureCasingGaugeTFlangeConnectionStyle"></param>
        public void PressureCasingGaugeTFlangeConnectionStyle_Writer(String pressureCasingGaugeTFlangeConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugeTFlangeConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 846
        /// API name: TEMP GAGE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugeTFlangeConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 601
        /// API name: TEMPERATURE GAUGE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <param name="PressureCasingGaugeTNPS"></param>
        public void PressureCasingGaugeTNPS_Writer(String pressureCasingGaugeTNPS)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugeTNPS))
                return;
        }

        /// <summary>
        /// Global number: 601
        /// API name: TEMPERATURE GAUGE-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugeTNPS_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 600
        /// API name: TEMPERATURE GAUGE-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:numberAtPosition
        /// </summary>
        /// <param name="PressureCasingGaugeTNumber"></param>
        public void PressureCasingGaugeTNumber_Writer(String pressureCasingGaugeTNumber)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugeTNumber))
                return;
        }

        /// <summary>
        /// Global number: 600
        /// API name: TEMPERATURE GAUGE-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:numberAtPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugeTNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 847
        /// API name: TEMP GAGE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:connectionPosition
        /// </summary>
        /// <param name="PressureCasingGaugeTPosition"></param>
        public void PressureCasingGaugeTPosition_Writer(String pressureCasingGaugeTPosition)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugeTPosition))
                return;
        }

        /// <summary>
        /// Global number: 847
        /// API name: TEMP GAGE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugeTPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 848
        /// API name: TEMP GAGE-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="PressureCasingGaugeTPRating"></param>
        public void PressureCasingGaugeTPRating_Writer(String pressureCasingGaugeTPRating)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugeTPRating))
                return;
        }

        /// <summary>
        /// Global number: 848
        /// API name: TEMP GAGE-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugeTPRating_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 602
        /// API name: TEMPERATURE GAUGE-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <param name="PressureCasingGaugeTWeldConnectionStyle"></param>
        public void PressureCasingGaugeTWeldConnectionStyle_Writer(String pressureCasingGaugeTWeldConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingGaugeTWeldConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 602
        /// API name: TEMPERATURE GAUGE-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Gauge-T"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingGaugeTWeldConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 742
        /// API name: GUSSET SUPPORT REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Unspecified"]/eq:isGussetSupportRequired
        /// </summary>
        /// <param name="PressureCasingIsGussetRequired"></param>
        public void PressureCasingIsGussetRequired_Writer(String pressureCasingIsGussetRequired)
        {
            if (String.IsNullOrEmpty(pressureCasingIsGussetRequired))
                return;
        }

        /// <summary>
        /// Global number: 742
        /// API name: GUSSET SUPPORT REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Unspecified"]/eq:isGussetSupportRequired
        /// </summary>
        /// <returns></returns>
        public String PressureCasingIsGussetRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 131
        /// API name: CYLINDRICAL THREADS REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Unspecified"]/eq:needCylindricalThread
        /// </summary>
        /// <param name="PressureCasingNeedCylindricalThread"></param>
        public void PressureCasingNeedCylindricalThread_Writer(String pressureCasingNeedCylindricalThread)
        {
            if (String.IsNullOrEmpty(pressureCasingNeedCylindricalThread))
                return;
        }

        /// <summary>
        /// Global number: 131
        /// API name: CYLINDRICAL THREADS REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Unspecified"]/eq:needCylindricalThread
        /// </summary>
        /// <returns></returns>
        public String PressureCasingNeedCylindricalThread_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 297
        /// API name: MACHINED AND STUDDED CONNECTIONS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Unspecified"]/eq:needMachineStuddedConnection
        /// </summary>
        /// <param name="PressureCasingNeedMachineStudConn"></param>
        public void PressureCasingNeedMachineStudConn_Writer(String pressureCasingNeedMachineStudConn)
        {
            if (String.IsNullOrEmpty(pressureCasingNeedMachineStudConn))
                return;
        }

        /// <summary>
        /// Global number: 297
        /// API name: MACHINED AND STUDDED CONNECTIONS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Unspecified"]/eq:needMachineStuddedConnection
        /// </summary>
        /// <returns></returns>
        public String PressureCasingNeedMachineStudConn_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 822
        /// API name: VENT-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="PressureCasingVentFlangeConnectionStyle"></param>
        public void PressureCasingVentFlangeConnectionStyle_Writer(String pressureCasingVentFlangeConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingVentFlangeConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 822
        /// API name: VENT-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingVentFlangeConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 642
        /// API name: VENT-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <param name="PressureCasingVentNPS"></param>
        public void PressureCasingVentNPS_Writer(String pressureCasingVentNPS)
        {
            if (String.IsNullOrEmpty(pressureCasingVentNPS))
                return;
        }

        /// <summary>
        /// Global number: 642
        /// API name: VENT-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String PressureCasingVentNPS_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 641
        /// API name: VENT-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:numberAtPosition
        /// </summary>
        /// <param name="PressureCasingVentNumber"></param>
        public void PressureCasingVentNumber_Writer(String pressureCasingVentNumber)
        {
            if (String.IsNullOrEmpty(pressureCasingVentNumber))
                return;
        }

        /// <summary>
        /// Global number: 641
        /// API name: VENT-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:numberAtPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingVentNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 823
        /// API name: VENT-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:connectionPosition
        /// </summary>
        /// <param name="PressureCasingVentPosition"></param>
        public void PressureCasingVentPosition_Writer(String pressureCasingVentPosition)
        {
            if (String.IsNullOrEmpty(pressureCasingVentPosition))
                return;
        }

        /// <summary>
        /// Global number: 823
        /// API name: VENT-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingVentPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 824
        /// API name: VENT-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="PressureCasingVentPRating"></param>
        public void PressureCasingVentPRating_Writer(String pressureCasingVentPRating)
        {
            if (String.IsNullOrEmpty(pressureCasingVentPRating))
                return;
        }

        /// <summary>
        /// Global number: 824
        /// API name: VENT-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Drain"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String PressureCasingVentPRating_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 859
        /// API name: VENT Valve Supplied By
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:bleedValveSuppliedBy
        /// </summary>
        /// <param name="PressureCasingVentVlvSupplier"></param>
        public void PressureCasingVentVlvSupplier_Writer(String pressureCasingVentVlvSupplier)
        {
            if (String.IsNullOrEmpty(pressureCasingVentVlvSupplier))
                return;
        }

        /// <summary>
        /// Global number: 859
        /// API name: VENT Valve Supplied By
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:bleedValveSuppliedBy
        /// </summary>
        /// <returns></returns>
        public String PressureCasingVentVlvSupplier_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 643
        /// API name: VENT-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <param name="PressureCasingVentWeldConnectionStyle"></param>
        public void PressureCasingVentWeldConnectionStyle_Writer(String pressureCasingVentWeldConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingVentWeldConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 643
        /// API name: VENT-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Vent"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingVentWeldConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 878
        /// API name: WARM-UP LINE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <param name="PressureCasingWarmUpFlangeConnectionStyle"></param>
        public void PressureCasingWarmUpFlangeConnectionStyle_Writer(String pressureCasingWarmUpFlangeConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingWarmUpFlangeConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 878
        /// API name: WARM-UP LINE-FAC'G
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:flangeConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingWarmUpFlangeConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 649
        /// API name: WARM UP-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <param name="PressureCasingWarmUpNPS"></param>
        public void PressureCasingWarmUpNPS_Writer(String pressureCasingWarmUpNPS)
        {
            if (String.IsNullOrEmpty(pressureCasingWarmUpNPS))
                return;
        }

        /// <summary>
        /// Global number: 649
        /// API name: WARM UP-SIZE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:endConnectionItem/eq:nominalPipeSize
        /// </summary>
        /// <returns></returns>
        public String PressureCasingWarmUpNPS_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 648
        /// API name: WARM UP LINE-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:numberAtPosition
        /// </summary>
        /// <param name="PressureCasingWarmUpNumber"></param>
        public void PressureCasingWarmUpNumber_Writer(String pressureCasingWarmUpNumber)
        {
            if (String.IsNullOrEmpty(pressureCasingWarmUpNumber))
                return;
        }

        /// <summary>
        /// Global number: 648
        /// API name: WARM UP LINE-NO.
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:numberAtPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingWarmUpNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 879
        /// API name: WARM-UP LINE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:connectionPosition
        /// </summary>
        /// <param name="PressureCasingWarmUpPosition"></param>
        public void PressureCasingWarmUpPosition_Writer(String pressureCasingWarmUpPosition)
        {
            if (String.IsNullOrEmpty(pressureCasingWarmUpPosition))
                return;
        }

        /// <summary>
        /// Global number: 879
        /// API name: WARM-UP LINE-POSITION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:connectionPosition
        /// </summary>
        /// <returns></returns>
        public String PressureCasingWarmUpPosition_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 880
        /// API name: WARM-UP LINE-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <param name="PressureCasingWarmUpPRating"></param>
        public void PressureCasingWarmUpPRating_Writer(String pressureCasingWarmUpPRating)
        {
            if (String.IsNullOrEmpty(pressureCasingWarmUpPRating))
                return;
        }

        /// <summary>
        /// Global number: 880
        /// API name: WARM-UP LINE-RATING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:endConnectionItem/eq:pressureRating/eq:pressureClass
        /// </summary>
        /// <returns></returns>
        public String PressureCasingWarmUpPRating_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 650
        /// API name: WARM UP-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <param name="PressureCasingWarmUpWeldConnectionStyle"></param>
        public void PressureCasingWarmUpWeldConnectionStyle_Writer(String pressureCasingWarmUpWeldConnectionStyle)
        {
            if (String.IsNullOrEmpty(pressureCasingWarmUpWeldConnectionStyle))
                return;
        }

        /// <summary>
        /// Global number: 650
        /// API name: WARM UP-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[eq:connectionType="Warm-up"]/eq:endDescription/eq:flangedAndWeldedConnection/eq:weldConnectionStyle
        /// </summary>
        /// <returns></returns>
        public String PressureCasingWarmUpWeldConnectionStyle_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 712
        /// API name: BOLT OH 3/4/5 PUMP TO PAD / FOUNDATION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:needBoltedOHPump
        /// </summary>
        /// <param name="PumpBoltedOHPump"></param>
        public void PumpBoltedOHPump_Writer(String pumpBoltedOHPump)
        {
            if (String.IsNullOrEmpty(pumpBoltedOHPump))
                return;
        }

        /// <summary>
        /// Global number: 712
        /// API name: BOLT OH 3/4/5 PUMP TO PAD / FOUNDATION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:needBoltedOHPump
        /// </summary>
        /// <returns></returns>
        public String PumpBoltedOHPump_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1743
        /// API name: Hydrotest Pressure at temperature
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingInspection/eqRot:casingTest/eqRot:hydrostaticTestT
        /// </summary>
        /// <param name="PumpCasingHydrostaticTestAtT"></param>
        public void PumpCasingHydrostaticTestAtT_Writer(String pumpCasingHydrostaticTestAtT)
        {
            if (String.IsNullOrEmpty(pumpCasingHydrostaticTestAtT))
                return;
        }

        /// <summary>
        /// Global number: 1743
        /// API name: Hydrotest Pressure at temperature
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingInspection/eqRot:casingTest/eqRot:hydrostaticTestT
        /// </summary>
        /// <returns></returns>
        public String PumpCasingHydrostaticTestAtT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 55
        /// API name: HYDROTEST OH PUMP AS ASSEMBLY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hydrostatic test as assembly"]/eq:isRequired
        /// </summary>
        /// <param name="PumpCasingHydrostaticTestFullAsmRequired"></param>
        public void PumpCasingHydrostaticTestFullAsmRequired_Writer(String pumpCasingHydrostaticTestFullAsmRequired)
        {
            if (String.IsNullOrEmpty(pumpCasingHydrostaticTestFullAsmRequired))
                return;
        }

        /// <summary>
        /// Global number: 55
        /// API name: HYDROTEST OH PUMP AS ASSEMBLY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hydrostatic test as assembly"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String PumpCasingHydrostaticTestFullAsmRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 54
        /// API name: HYDROTEST PRESSURE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingInspection/eqRot:casingTest/eqRot:hydrostaticTestP[@basis="gauge"]
        /// </summary>
        /// <param name="PumpCasingHydrostaticTestP"></param>
        public void PumpCasingHydrostaticTestP_Writer(String pumpCasingHydrostaticTestP)
        {
            if (String.IsNullOrEmpty(pumpCasingHydrostaticTestP))
                return;
        }

        /// <summary>
        /// Global number: 54
        /// API name: HYDROTEST PRESSURE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingInspection/eqRot:casingTest/eqRot:hydrostaticTestP[@basis="gauge"]
        /// </summary>
        /// <returns></returns>
        public String PumpCasingHydrostaticTestP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 56
        /// API name: MAWP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eq:mechanicalDesignRequirement/eq:mawp
        /// </summary>
        /// <param name="PumpCasingMAWP"></param>
        public void PumpCasingMAWP_Writer(String pumpCasingMAWP)
        {
            if (String.IsNullOrEmpty(pumpCasingMAWP))
                return;
        }

        /// <summary>
        /// Global number: 56
        /// API name: MAWP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eq:mechanicalDesignRequirement/eq:mawp
        /// </summary>
        /// <returns></returns>
        public String PumpCasingMAWP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 57
        /// API name: at temperature-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eq:mechanicalDesignRequirement/eq:mawpT
        /// </summary>
        /// <param name="PumpCasingMAWPT"></param>
        public void PumpCasingMAWPT_Writer(String pumpCasingMAWPT)
        {
            if (String.IsNullOrEmpty(pumpCasingMAWPT))
                return;
        }

        /// <summary>
        /// Global number: 57
        /// API name: at temperature-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eq:mechanicalDesignRequirement/eq:mawpT
        /// </summary>
        /// <returns></returns>
        public String PumpCasingMAWPT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 58
        /// API name: CASING MOUNTING:-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingMounting
        /// </summary>
        /// <param name="PumpCasingMounting"></param>
        public void PumpCasingMounting_Writer(String pumpCasingMounting)
        {
            if (String.IsNullOrEmpty(pumpCasingMounting))
                return;
        }

        /// <summary>
        /// Global number: 58
        /// API name: CASING MOUNTING:-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingMounting
        /// </summary>
        /// <returns></returns>
        public String PumpCasingMounting_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 579
        /// API name: PUMP SUCTION REGION DESIGNED FOR MAWP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:isSuctionRegionDesignForMAWP
        /// </summary>
        /// <param name="PumpCasingSuctionRegionForMAWP"></param>
        public void PumpCasingSuctionRegionForMAWP_Writer(String pumpCasingSuctionRegionForMAWP)
        {
            if (String.IsNullOrEmpty(pumpCasingSuctionRegionForMAWP))
                return;
        }

        /// <summary>
        /// Global number: 579
        /// API name: PUMP SUCTION REGION DESIGNED FOR MAWP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:isSuctionRegionDesignForMAWP
        /// </summary>
        /// <returns></returns>
        public String PumpCasingSuctionRegionForMAWP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 59
        /// API name: CASING TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingType
        /// </summary>
        /// <param name="PumpCasingType"></param>
        public void PumpCasingType_Writer(String pumpCasingType)
        {
            if (String.IsNullOrEmpty(pumpCasingType))
                return;
        }

        /// <summary>
        /// Global number: 59
        /// API name: CASING TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:casing/eqRot:casingType
        /// </summary>
        /// <returns></returns>
        public String PumpCasingType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 740
        /// API name: First Critical Speed Wet
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:calculateFirstCriticalSpeedWet
        /// </summary>
        /// <param name="PumpDesignCalc1stCriticalSpdWet"></param>
        public void PumpDesignCalc1stCriticalSpdWet_Writer(String pumpDesignCalc1stCriticalSpdWet)
        {
            if (String.IsNullOrEmpty(pumpDesignCalc1stCriticalSpdWet))
                return;
        }

        /// <summary>
        /// Global number: 740
        /// API name: First Critical Speed Wet
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:calculateFirstCriticalSpeedWet
        /// </summary>
        /// <returns></returns>
        public String PumpDesignCalc1stCriticalSpdWet_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 311
        /// API name: ANNEX H CLASS-
        /// eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="PumpExtMaterialClassIDName"></param>
        public void PumpExtMaterialClassIDName_Writer(String pumpExtMaterialClassIDName)
        {
            if (String.IsNullOrEmpty(pumpExtMaterialClassIDName))
                return;
        }

        /// <summary>
        /// Global number: 311
        /// API name: ANNEX H CLASS-
        /// eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String PumpExtMaterialClassIDName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 392
        /// API name: OH3 BACKPULLOUT LIFTING DEVICE REQD.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:hasOH3BearingLifter
        /// </summary>
        /// <param name="PumpHasOH3BearingLifter"></param>
        public void PumpHasOH3BearingLifter_Writer(String pumpHasOH3BearingLifter)
        {
            if (String.IsNullOrEmpty(pumpHasOH3BearingLifter))
                return;
        }

        /// <summary>
        /// Global number: 392
        /// API name: OH3 BACKPULLOUT LIFTING DEVICE REQD.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:hasOH3BearingLifter
        /// </summary>
        /// <returns></returns>
        public String PumpHasOH3BearingLifter_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 745
        /// API name: IMPELLERS INDIVIDUALLY SECURED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/eqRot:isIndividuallySecured
        /// </summary>
        /// <param name="PumpImpellerIndividuallySecured"></param>
        public void PumpImpellerIndividuallySecured_Writer(String pumpImpellerIndividuallySecured)
        {
            if (String.IsNullOrEmpty(pumpImpellerIndividuallySecured))
                return;
        }

        /// <summary>
        /// Global number: 745
        /// API name: IMPELLERS INDIVIDUALLY SECURED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/eqRot:isIndividuallySecured
        /// </summary>
        /// <returns></returns>
        public String PumpImpellerIndividuallySecured_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 342
        /// API name: MIN DESIGN METAL TEMP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:mechanicalDesignRequirement/eq:minDesignMetalT
        /// </summary>
        /// <param name="PumpMinDesignMetalT"></param>
        public void PumpMinDesignMetalT_Writer(String pumpMinDesignMetalT)
        {
            if (String.IsNullOrEmpty(pumpMinDesignMetalT))
                return;
        }

        /// <summary>
        /// Global number: 342
        /// API name: MIN DESIGN METAL TEMP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:mechanicalDesignRequirement/eq:minDesignMetalT
        /// </summary>
        /// <returns></returns>
        public String PumpMinDesignMetalT_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 485
        /// API name: REDUCED-HARDNESS MATERIALS REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:material/eq:reducedHardnessMaterialRequired
        /// </summary>
        /// <param name="PumpReducedHardnessMtrlReq"></param>
        public void PumpReducedHardnessMtrlReq_Writer(String pumpReducedHardnessMtrlReq)
        {
            if (String.IsNullOrEmpty(pumpReducedHardnessMtrlReq))
                return;
        }

        /// <summary>
        /// Global number: 485
        /// API name: REDUCED-HARDNESS MATERIALS REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:material/eq:reducedHardnessMaterialRequired
        /// </summary>
        /// <returns></returns>
        public String PumpReducedHardnessMtrlReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 703
        /// API name: Applicable Hardness Standard
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:material/eq:reducedHardnessMaterialStandard
        /// </summary>
        /// <param name="PumpReducedHardnessMtrlStd"></param>
        public void PumpReducedHardnessMtrlStd_Writer(String pumpReducedHardnessMtrlStd)
        {
            if (String.IsNullOrEmpty(pumpReducedHardnessMtrlStd))
                return;
        }

        /// <summary>
        /// Global number: 703
        /// API name: Applicable Hardness Standard
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:material/eq:reducedHardnessMaterialStandard
        /// </summary>
        /// <returns></returns>
        public String PumpReducedHardnessMtrlStd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 77
        /// API name: COMPONENT BALANCE TO ISO 1940 G1.0-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:rotor/eqRot:needBalanceToISO1940
        /// </summary>
        /// <param name="PumpRotorBalanceToISO1940"></param>
        public void PumpRotorBalanceToISO1940_Writer(String pumpRotorBalanceToISO1940)
        {
            if (String.IsNullOrEmpty(pumpRotorBalanceToISO1940))
                return;
        }

        /// <summary>
        /// Global number: 77
        /// API name: COMPONENT BALANCE TO ISO 1940 G1.0-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:rotor/eqRot:needBalanceToISO1940
        /// </summary>
        /// <returns></returns>
        public String PumpRotorBalanceToISO1940_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 531
        /// API name: SHRINK FIT -LIMITED MOVEMENT IMPELLERS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:rotor/eqRot:hasShrinkFitLimitedMovementImpeller
        /// </summary>
        /// <param name="PumpRotorShrinkFitImpeller"></param>
        public void PumpRotorShrinkFitImpeller_Writer(String pumpRotorShrinkFitImpeller)
        {
            if (String.IsNullOrEmpty(pumpRotorShrinkFitImpeller))
                return;
        }

        /// <summary>
        /// Global number: 531
        /// API name: SHRINK FIT -LIMITED MOVEMENT IMPELLERS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:rotor/eqRot:hasShrinkFitLimitedMovementImpeller
        /// </summary>
        /// <returns></returns>
        public String PumpRotorShrinkFitImpeller_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 467
        /// API name: PUMP TYPE: -
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:pumpTypeClassification
        /// </summary>
        /// <param name="PumpTypeClassification"></param>
        public void PumpTypeClassification_Writer(String pumpTypeClassification)
        {
            if (String.IsNullOrEmpty(pumpTypeClassification))
                return;
        }

        /// <summary>
        /// Global number: 467
        /// API name: PUMP TYPE: -
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:pumpTypeClassification
        /// </summary>
        /// <returns></returns>
        public String PumpTypeClassification_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 43
        /// API name: BEARING RADIAL-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:radialBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <param name="RadialBearingNumber"></param>
        public void RadialBearingNumber_Writer(String radialBearingNumber)
        {
            if (String.IsNullOrEmpty(radialBearingNumber))
                return;
        }

        /// <summary>
        /// Global number: 43
        /// API name: BEARING RADIAL-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:radialBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <returns></returns>
        public String RadialBearingNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 44
        /// API name: BEARING RADIAL-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:radialBearing/eq:radialBearingType
        /// </summary>
        /// <param name="RadialBearingType"></param>
        public void RadialBearingType_Writer(String radialBearingType)
        {
            if (String.IsNullOrEmpty(radialBearingType))
                return;
        }

        /// <summary>
        /// Global number: 44
        /// API name: BEARING RADIAL-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:radialBearing/eq:radialBearingType
        /// </summary>
        /// <returns></returns>
        public String RadialBearingType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 503
        /// API name: ROTATION:-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/eqRot:rotationDirection
        /// </summary>
        /// <param name="RotationDirectionFromCouplingEnd"></param>
        public void RotationDirectionFromCouplingEnd_Writer(String rotationDirectionFromCouplingEnd)
        {
            if (String.IsNullOrEmpty(rotationDirectionFromCouplingEnd))
                return;
        }

        /// <summary>
        /// Global number: 503
        /// API name: ROTATION:-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:impeller[etl:propertyType="Unspecified"]/eqRot:rotationDirection
        /// </summary>
        /// <returns></returns>
        public String RotationDirectionFromCouplingEnd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 816
        /// API name: SHAFT FLEXIBILITY INDEX SFI
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:shaft/eq:shaftFlexibilityIndex
        /// </summary>
        /// <param name="ShaftFlexibilityIndex"></param>
        public void ShaftFlexibilityIndex_Writer(String shaftFlexibilityIndex)
        {
            if (String.IsNullOrEmpty(shaftFlexibilityIndex))
                return;
        }

        /// <summary>
        /// Global number: 816
        /// API name: SHAFT FLEXIBILITY INDEX SFI
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:shaft/eq:shaftFlexibilityIndex
        /// </summary>
        /// <returns></returns>
        public String ShaftFlexibilityIndex_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 525
        /// API name: SHAFT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:shaft/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="ShaftMaterialName"></param>
        public void ShaftMaterialName_Writer(String shaftMaterialName)
        {
            if (String.IsNullOrEmpty(shaftMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 525
        /// API name: SHAFT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:shaft/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String ShaftMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 747
        /// API name: Inspection Class
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpTestStandard="API 610"][eq:inspectionComponent/eq:inspectionComponentType="Materials"]/eq:description
        /// </summary>
        /// <param name="TestMaterialAPIClassDesc"></param>
        public void TestMaterialAPIClassDesc_Writer(String testMaterialAPIClassDesc)
        {
            if (String.IsNullOrEmpty(testMaterialAPIClassDesc))
                return;
        }

        /// <summary>
        /// Global number: 747
        /// API name: Inspection Class
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpTestStandard="API 610"][eq:inspectionComponent/eq:inspectionComponentType="Materials"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestMaterialAPIClassDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 46
        /// API name: BEARING THRUST-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:thrustBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <param name="ThrustBearingNumber"></param>
        public void ThrustBearingNumber_Writer(String thrustBearingNumber)
        {
            if (String.IsNullOrEmpty(thrustBearingNumber))
                return;
        }

        /// <summary>
        /// Global number: 46
        /// API name: BEARING THRUST-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:thrustBearing/eq:id/eq:serialNumber
        /// </summary>
        /// <returns></returns>
        public String ThrustBearingNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 47
        /// API name: BEARING THRUST-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:thrustBearing/eq:thrustBearingType
        /// </summary>
        /// <param name="ThrustBearingType"></param>
        public void ThrustBearingType_Writer(String thrustBearingType)
        {
            if (String.IsNullOrEmpty(thrustBearingType))
                return;
        }

        /// <summary>
        /// Global number: 47
        /// API name: BEARING THRUST-TYPE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:thrustBearing/eq:thrustBearingType
        /// </summary>
        /// <returns></returns>
        public String ThrustBearingType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 713
        /// API name: Bowl (if VS-type)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpBowlMaterialName"></param>
        public void VertPumpBowlMaterialName_Writer(String vertPumpBowlMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpBowlMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 713
        /// API name: Bowl (if VS-type)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpBowlMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 864
        /// API name: VS6 Drain-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:verticalPumpDrainLocation
        /// </summary>
        /// <param name="VertPumpDrainLocation"></param>
        public void VertPumpDrainLocation_Writer(String vertPumpDrainLocation)
        {
            if (String.IsNullOrEmpty(vertPumpDrainLocation))
                return;
        }

        /// <summary>
        /// Global number: 864
        /// API name: VS6 Drain-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:verticalPumpDrainLocation
        /// </summary>
        /// <returns></returns>
        public String VertPumpDrainLocation_Reader()
        {
            return null;
        } 
        #endregion

        #region Page 4
        /// <summary>
        /// Global number: 303
        /// API name: MANIFOLD PIPING-COOLING WATER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[@usageContext="Construction specification"][eq:connectionType="Cooling water"]/eq:needSingleManifold
        /// </summary>
        /// <param name="ConnectionCWConstructionSingleManifold"></param>
        public void ConnectionCWConstructionSingleManifold_Writer(String connectionCWConstructionSingleManifold)
        {
            if (String.IsNullOrEmpty(connectionCWConstructionSingleManifold))
                return;
        }

        /// <summary>
        /// Global number: 303
        /// API name: MANIFOLD PIPING-COOLING WATER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection[@usageContext="Construction specification"][eq:connectionType="Cooling water"]/eq:needSingleManifold
        /// </summary>
        /// <returns></returns>
        public String ConnectionCWConstructionSingleManifold_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 304
        /// API name: MANIFOLD PIPING-DRAIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Construction specification"][eq:connectionType="Drain"]/eq:needSingleManifold
        /// </summary>
        /// <param name="ConnectionDrainConstructionSingleManifold"></param>
        public void ConnectionDrainConstructionSingleManifold_Writer(String connectionDrainConstructionSingleManifold)
        {
            if (String.IsNullOrEmpty(connectionDrainConstructionSingleManifold))
                return;
        }

        /// <summary>
        /// Global number: 304
        /// API name: MANIFOLD PIPING-DRAIN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Construction specification"][eq:connectionType="Drain"]/eq:needSingleManifold
        /// </summary>
        /// <returns></returns>
        public String ConnectionDrainConstructionSingleManifold_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 845
        /// API name: TAG ALL ORIFICES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:isOrificeTagRequired
        /// </summary>
        /// <param name="ConnectionOrificeTagRequired"></param>
        public void ConnectionOrificeTagRequired_Writer(String connectionOrificeTagRequired)
        {
            if (String.IsNullOrEmpty(connectionOrificeTagRequired))
                return;
        }

        /// <summary>
        /// Global number: 845
        /// API name: TAG ALL ORIFICES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:isOrificeTagRequired
        /// </summary>
        /// <returns></returns>
        public String ConnectionOrificeTagRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 305
        /// API name: MANIFOLD PIPING FOR PURCHASER CONNECTION-VENT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Construction specification"][eq:connectionType="Vent"]/eq:needSingleManifold
        /// </summary>
        /// <param name="ConnectionVentConstructionSingleManifold"></param>
        public void ConnectionVentConstructionSingleManifold_Writer(String connectionVentConstructionSingleManifold)
        {
            if (String.IsNullOrEmpty(connectionVentConstructionSingleManifold))
                return;
        }

        /// <summary>
        /// Global number: 305
        /// API name: MANIFOLD PIPING FOR PURCHASER CONNECTION-VENT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:pressureCasing/eq:equipmentConnection[@usageContext="Construction specification"][eq:connectionType="Vent"]/eq:needSingleManifold
        /// </summary>
        /// <returns></returns>
        public String ConnectionVentConstructionSingleManifold_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 767
        /// API name: Mounting Location of Accelerometers_3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:needFlatSurface="true"][eq:itemRequirement="Unspecified"]/eq:locationDescription
        /// </summary>
        /// <param name="InstrumentationAccFlatSurfaceLocationDesc"></param>
        public void InstrumentationAccFlatSurfaceLocationDesc_Writer(String instrumentationAccFlatSurfaceLocationDesc)
        {
            if (String.IsNullOrEmpty(instrumentationAccFlatSurfaceLocationDesc))
                return;
        }

        /// <summary>
        /// Global number: 767
        /// API name: Mounting Location of Accelerometers_3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:needFlatSurface="true"][eq:itemRequirement="Unspecified"]/eq:locationDescription
        /// </summary>
        /// <returns></returns>
        public String InstrumentationAccFlatSurfaceLocationDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 791
        /// API name: Number of Accelerometers_3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:needFlatSurface="true"][eq:itemRequirement="Unspecified"]/eq:numberRequired
        /// </summary>
        /// <param name="InstrumentationAccFlatSurfaceNoReq"></param>
        public void InstrumentationAccFlatSurfaceNoReq_Writer(String instrumentationAccFlatSurfaceNoReq)
        {
            if (String.IsNullOrEmpty(instrumentationAccFlatSurfaceNoReq))
                return;
        }

        /// <summary>
        /// Global number: 791
        /// API name: Number of Accelerometers_3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:needFlatSurface="true"][eq:itemRequirement="Unspecified"]/eq:numberRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationAccFlatSurfaceNoReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 765
        /// API name: Mounting Location of Accelerometers_1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Installed"]/eq:locationDescription
        /// </summary>
        /// <param name="InstrumentationAccInstalledLocationDesc"></param>
        public void InstrumentationAccInstalledLocationDesc_Writer(String instrumentationAccInstalledLocationDesc)
        {
            if (String.IsNullOrEmpty(instrumentationAccInstalledLocationDesc))
                return;
        }

        /// <summary>
        /// Global number: 765
        /// API name: Mounting Location of Accelerometers_1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Installed"]/eq:locationDescription
        /// </summary>
        /// <returns></returns>
        public String InstrumentationAccInstalledLocationDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 789
        /// API name: Number of Accelerometers_1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Installed"]/eq:numberRequired
        /// </summary>
        /// <param name="InstrumentationAccInstalledNoReq"></param>
        public void InstrumentationAccInstalledNoReq_Writer(String instrumentationAccInstalledNoReq)
        {
            if (String.IsNullOrEmpty(instrumentationAccInstalledNoReq))
                return;
        }

        /// <summary>
        /// Global number: 789
        /// API name: Number of Accelerometers_1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Installed"]/eq:numberRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationAccInstalledNoReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 220
        /// API name: FLAT SURFACE REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <param name="InstrumentationAccNeedFlatSurface"></param>
        public void InstrumentationAccNeedFlatSurface_Writer(String instrumentationAccNeedFlatSurface)
        {
            if (String.IsNullOrEmpty(instrumentationAccNeedFlatSurface))
                return;
        }

        /// <summary>
        /// Global number: 220
        /// API name: FLAT SURFACE REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationAccNeedFlatSurface_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 766
        /// API name: Mounting Location of Accelerometers_2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Provisions only"]/eq:locationDescription
        /// </summary>
        /// <param name="InstrumentationAccProvisionLocationDesc"></param>
        public void InstrumentationAccProvisionLocationDesc_Writer(String instrumentationAccProvisionLocationDesc)
        {
            if (String.IsNullOrEmpty(instrumentationAccProvisionLocationDesc))
                return;
        }

        /// <summary>
        /// Global number: 766
        /// API name: Mounting Location of Accelerometers_2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Provisions only"]/eq:locationDescription
        /// </summary>
        /// <returns></returns>
        public String InstrumentationAccProvisionLocationDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 790
        /// API name: Number of Accelerometers_2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Provisions only"]/eq:numberRequired
        /// </summary>
        /// <param name="InstrumentationAccProvisionNoReq"></param>
        public void InstrumentationAccProvisionNoReq_Writer(String instrumentationAccProvisionNoReq)
        {
            if (String.IsNullOrEmpty(instrumentationAccProvisionNoReq))
                return;
        }

        /// <summary>
        /// Global number: 790
        /// API name: Number of Accelerometers_2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Accelerometer"][eq:itemRequirement="Provisions only"]/eq:numberRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationAccProvisionNoReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 793
        /// API name: NUMBER PER THRUST BEARING ACTIVE SIDE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Thrust - active side"]/eq:numberRequired
        /// </summary>
        /// <param name="InstrumentationActThrustBearingTProbeNoReq"></param>
        public void InstrumentationActThrustBearingTProbeNoReq_Writer(String instrumentationActThrustBearingTProbeNoReq)
        {
            if (String.IsNullOrEmpty(instrumentationActThrustBearingTProbeNoReq))
                return;
        }

        /// <summary>
        /// Global number: 793
        /// API name: NUMBER PER THRUST BEARING ACTIVE SIDE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Thrust - active side"]/eq:numberRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationActThrustBearingTProbeNoReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 794
        /// API name: NUMBER PER THRUST BEARING INACTIVE SIDE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Thrust - inactive side"]/eq:numberRequired
        /// </summary>
        /// <param name="InstrumentationInactThrustBearingTProbeNoReq"></param>
        public void InstrumentationInactThrustBearingTProbeNoReq_Writer(String instrumentationInactThrustBearingTProbeNoReq)
        {
            if (String.IsNullOrEmpty(instrumentationInactThrustBearingTProbeNoReq))
                return;
        }

        /// <summary>
        /// Global number: 794
        /// API name: NUMBER PER THRUST BEARING INACTIVE SIDE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Thrust - inactive side"]/eq:numberRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationInactThrustBearingTProbeNoReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 17
        /// API name: SEE ATTACHED API-670 DATA SHEET-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Instrumentation"]/ctx:organizationContext[ctx:organization/objb:name="API"]/ctx:id
        /// </summary>
        /// <param name="InstrumentationISOAPIDataSheetID"></param>
        public void InstrumentationISOAPIDataSheetID_Writer(String instrumentationISOAPIDataSheetID)
        {
            if (String.IsNullOrEmpty(instrumentationISOAPIDataSheetID))
                return;
        }

        /// <summary>
        /// Global number: 17
        /// API name: SEE ATTACHED API-670 DATA SHEET-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Instrumentation"]/ctx:organizationContext[ctx:organization/objb:name="API"]/ctx:id
        /// </summary>
        /// <returns></returns>
        public String InstrumentationISOAPIDataSheetID_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 51
        /// API name: MONITORS AND CABLES SUPPLIED BY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:monitorCableSuppliedBy
        /// </summary>
        /// <param name="InstrumentationMonitorCableSuppliedBy"></param>
        public void InstrumentationMonitorCableSuppliedBy_Writer(String instrumentationMonitorCableSuppliedBy)
        {
            if (String.IsNullOrEmpty(instrumentationMonitorCableSuppliedBy))
                return;
        }

        /// <summary>
        /// Global number: 51
        /// API name: MONITORS AND CABLES SUPPLIED BY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:monitorCableSuppliedBy
        /// </summary>
        /// <returns></returns>
        public String InstrumentationMonitorCableSuppliedBy_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 435
        /// API name: PRESSURE GAUGE TYPE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement[eq:controlSystemVariable="Pressure"][eq:needGaugeOrMeter="true"]/eq:remark
        /// </summary>
        /// <param name="InstrumentationPGaugeRemark"></param>
        public void InstrumentationPGaugeRemark_Writer(String instrumentationPGaugeRemark)
        {
            if (String.IsNullOrEmpty(instrumentationPGaugeRemark))
                return;
        }

        /// <summary>
        /// Global number: 435
        /// API name: PRESSURE GAUGE TYPE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement[eq:controlSystemVariable="Pressure"][eq:needGaugeOrMeter="true"]/eq:remark
        /// </summary>
        /// <returns></returns>
        public String InstrumentationPGaugeRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 792
        /// API name: NUMBER PER RADIAL BEARING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Radial"]/eq:numberRequired
        /// </summary>
        /// <param name="InstrumentationRadialBearingTProbeNoReq"></param>
        public void InstrumentationRadialBearingTProbeNoReq_Writer(String instrumentationRadialBearingTProbeNoReq)
        {
            if (String.IsNullOrEmpty(instrumentationRadialBearingTProbeNoReq))
                return;
        }

        /// <summary>
        /// Global number: 792
        /// API name: NUMBER PER RADIAL BEARING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Radial"]/eq:numberRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationRadialBearingTProbeNoReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 471
        /// API name: RADIAL BEARING TEMP.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Radial"]/eq:isRequired
        /// </summary>
        /// <param name="InstrumentationRadialBearingTProbeReq"></param>
        public void InstrumentationRadialBearingTProbeReq_Writer(String instrumentationRadialBearingTProbeReq)
        {
            if (String.IsNullOrEmpty(instrumentationRadialBearingTProbeReq))
                return;
        }

        /// <summary>
        /// Global number: 471
        /// API name: RADIAL BEARING TEMP.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Radial"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationRadialBearingTProbeReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 278
        /// API name: INSTRUMENTATION -Remarks
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:bearingItem/eq:instrumentationRequirement/eq:remark
        /// </summary>
        /// <param name="InstrumentationRemark"></param>
        public void InstrumentationRemark_Writer(String instrumentationRemark)
        {
            if (String.IsNullOrEmpty(instrumentationRemark))
                return;
        }

        /// <summary>
        /// Global number: 278
        /// API name: INSTRUMENTATION -Remarks
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:bearingItem/eq:instrumentationRequirement/eq:remark
        /// </summary>
        /// <returns></returns>
        public String InstrumentationRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 599
        /// API name: TEMP. GAUGES (WITH THERMOWELLS)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Thermowell with temperature gauge"]/eq:isRequired
        /// </summary>
        /// <param name="InstrumentationThermoWellTGaugeReq"></param>
        public void InstrumentationThermoWellTGaugeReq_Writer(String instrumentationThermoWellTGaugeReq)
        {
            if (String.IsNullOrEmpty(instrumentationThermoWellTGaugeReq))
                return;
        }

        /// <summary>
        /// Global number: 599
        /// API name: TEMP. GAUGES (WITH THERMOWELLS)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Thermowell with temperature gauge"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationThermoWellTGaugeReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 605
        /// API name: THRUST BEARING TEMP.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Thrust"]/eq:isRequired
        /// </summary>
        /// <param name="InstrumentationThrustBearingTProbeReq"></param>
        public void InstrumentationThrustBearingTProbeReq_Writer(String instrumentationThrustBearingTProbeReq)
        {
            if (String.IsNullOrEmpty(instrumentationThrustBearingTProbeReq))
                return;
        }

        /// <summary>
        /// Global number: 605
        /// API name: THRUST BEARING TEMP.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Installed"][eq:bearingTypeToMonitor="Thrust"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationThrustBearingTProbeReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 808
        /// API name: PROVISIONS FOR TEMP PROBES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <param name="InstrumentationTProbeProvision"></param>
        public void InstrumentationTProbeProvision_Writer(String instrumentationTProbeProvision)
        {
            if (String.IsNullOrEmpty(instrumentationTProbeProvision))
                return;
        }

        /// <summary>
        /// Global number: 808
        /// API name: PROVISIONS FOR TEMP PROBES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:temperatureInstrumentation[eq:temperatureSensorType="Unspecified"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationTProbeProvision_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 448
        /// API name: PROVISIONS FOR VIB. PROBES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Unspecified"][eq:vibrationProbeType="Unspecified"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <param name="InstrumentationVibProbeProvision"></param>
        public void InstrumentationVibProbeProvision_Writer(String instrumentationVibProbeProvision)
        {
            if (String.IsNullOrEmpty(instrumentationVibProbeProvision))
                return;
        }

        /// <summary>
        /// Global number: 448
        /// API name: PROVISIONS FOR VIB. PROBES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Unspecified"][eq:vibrationProbeType="Unspecified"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationVibProbeProvision_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 472
        /// API name: NUMBER PER RADIAL BEARING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Unspecified"][eq:vibrationProbeType="Radial"][eq:itemRequirement="Provisions only"]/eq:numberPerItem
        /// </summary>
        /// <param name="InstrumentationVibRadialPerBearing"></param>
        public void InstrumentationVibRadialPerBearing_Writer(String instrumentationVibRadialPerBearing)
        {
            if (String.IsNullOrEmpty(instrumentationVibRadialPerBearing))
                return;
        }

        /// <summary>
        /// Global number: 472
        /// API name: NUMBER PER RADIAL BEARING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:instrumentationRequirement/eqRot:vibrationInstrumentation[eq:transducerDescriptionType="Unspecified"][eq:vibrationProbeType="Radial"][eq:itemRequirement="Provisions only"]/eq:numberPerItem
        /// </summary>
        /// <returns></returns>
        public String InstrumentationVibRadialPerBearing_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 447
        /// API name: PROVISION FOR MTG ONLY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:bearingItem/eq:instrumentationRequirement/eq:vibrationInstrumentation[eq:transducerDescriptionType="Unspecified"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <param name="InstrumentationVibTransducerProvisionForMnt"></param>
        public void InstrumentationVibTransducerProvisionForMnt_Writer(String instrumentationVibTransducerProvisionForMnt)
        {
            if (String.IsNullOrEmpty(instrumentationVibTransducerProvisionForMnt))
                return;
        }

        /// <summary>
        /// Global number: 447
        /// API name: PROVISION FOR MTG ONLY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:bearingAssembly/eq:bearingDetail/eq:bearingItem/eq:instrumentationRequirement/eq:vibrationInstrumentation[eq:transducerDescriptionType="Unspecified"][eq:itemRequirement="Provisions only"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstrumentationVibTransducerProvisionForMnt_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 18
        /// API name: SEE ATTACHED ISO 21049/API 682 DATA SHEET-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Seal - mechanical"]/ctx:organizationContext[ctx:organization/objb:name="ISO/API"]/ctx:id
        /// </summary>
        /// <param name="MechSealISOAPIDataSheetID"></param>
        public void MechSealISOAPIDataSheetID_Writer(String mechSealISOAPIDataSheetID)
        {
            if (String.IsNullOrEmpty(mechSealISOAPIDataSheetID))
                return;
        }

        /// <summary>
        /// Global number: 18
        /// API name: SEE ATTACHED ISO 21049/API 682 DATA SHEET-
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Seal - mechanical"]/ctx:organizationContext[ctx:organization/objb:name="ISO/API"]/ctx:id
        /// </summary>
        /// <returns></returns>
        public String MechSealISOAPIDataSheetID_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 90
        /// API name: COOLING REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeating="Cooling"]/eqRot:isRequired
        /// </summary>
        /// <param name="PumpAuxCoolingRequired"></param>
        public void PumpAuxCoolingRequired_Writer(String pumpAuxCoolingRequired)
        {
            if (String.IsNullOrEmpty(pumpAuxCoolingRequired))
                return;
        }

        /// <summary>
        /// Global number: 90
        /// API name: COOLING REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeating="Cooling"]/eqRot:isRequired
        /// </summary>
        /// <returns></returns>
        public String PumpAuxCoolingRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 126
        /// API name: COOLING WATER REQUIREMENTS:-BEARING HOUSING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating/eq:coolingHeatingFluid[eq:materialUtilityServiceType="Cooling water"][eq:utilityDemandDeviceType="Bearing housing"]/eq:materialUtilityCondition/eq:flowVolume
        /// </summary>
        /// <param name="PumpAuxCoolingWaterBearingHseFlowVolume"></param>
        public void PumpAuxCoolingWaterBearingHseFlowVolume_Writer(String pumpAuxCoolingWaterBearingHseFlowVolume)
        {
            if (String.IsNullOrEmpty(pumpAuxCoolingWaterBearingHseFlowVolume))
                return;
        }

        /// <summary>
        /// Global number: 126
        /// API name: COOLING WATER REQUIREMENTS:-BEARING HOUSING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating/eq:coolingHeatingFluid[eq:materialUtilityServiceType="Cooling water"][eq:utilityDemandDeviceType="Bearing housing"]/eq:materialUtilityCondition/eq:flowVolume
        /// </summary>
        /// <returns></returns>
        public String PumpAuxCoolingWaterBearingHseFlowVolume_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 128
        /// API name: COOLING WATER -HEAT EXCHANGER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating/eq:coolingHeatingFluid[eq:materialUtilityServiceType="Cooling water"][eq:utilityDemandDeviceType="Heat exchanger"]/eq:materialUtilityCondition/eq:flowVolume
        /// </summary>
        /// <param name="PumpAuxCoolingWaterHXFlowVolume"></param>
        public void PumpAuxCoolingWaterHXFlowVolume_Writer(String pumpAuxCoolingWaterHXFlowVolume)
        {
            if (String.IsNullOrEmpty(pumpAuxCoolingWaterHXFlowVolume))
                return;
        }

        /// <summary>
        /// Global number: 128
        /// API name: COOLING WATER -HEAT EXCHANGER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating/eq:coolingHeatingFluid[eq:materialUtilityServiceType="Cooling water"][eq:utilityDemandDeviceType="Heat exchanger"]/eq:materialUtilityCondition/eq:flowVolume
        /// </summary>
        /// <returns></returns>
        public String PumpAuxCoolingWaterHXFlowVolume_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 87
        /// API name: COOLING WATER PIPING MATERIALS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeatingFluid/eq:materialUtilityServiceType="Cooling water"]/eqRot:pipeTubeConstructionMaterial/mtrl:material/objb:name
        /// </summary>
        /// <param name="PumpAuxCoolingWaterPipingMaterial"></param>
        public void PumpAuxCoolingWaterPipingMaterial_Writer(String pumpAuxCoolingWaterPipingMaterial)
        {
            if (String.IsNullOrEmpty(pumpAuxCoolingWaterPipingMaterial))
                return;
        }

        /// <summary>
        /// Global number: 87
        /// API name: COOLING WATER PIPING MATERIALS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeatingFluid/eq:materialUtilityServiceType="Cooling water"]/eqRot:pipeTubeConstructionMaterial/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String PumpAuxCoolingWaterPipingMaterial_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 89
        /// API name: COOLING WATER PIPING PLAN-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeatingFluid/eq:materialUtilityServiceType="Cooling water"]/eqRot:pipingPlanDescription
        /// </summary>
        /// <param name="PumpAuxCoolingWaterPipingPlan"></param>
        public void PumpAuxCoolingWaterPipingPlan_Writer(String pumpAuxCoolingWaterPipingPlan)
        {
            if (String.IsNullOrEmpty(pumpAuxCoolingWaterPipingPlan))
                return;
        }

        /// <summary>
        /// Global number: 89
        /// API name: COOLING WATER PIPING PLAN-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeatingFluid/eq:materialUtilityServiceType="Cooling water"]/eqRot:pipingPlanDescription
        /// </summary>
        /// <returns></returns>
        public String PumpAuxCoolingWaterPipingPlan_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 130
        /// API name: TOTAL COOLING WATER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating/eq:coolingHeatingFluid[eq:materialUtilityServiceType="Cooling water"][eq:utilityDemandDeviceType="Total system"]/eq:materialUtilityCondition[etl:propertyType="Total"]/eq:flowVolume
        /// </summary>
        /// <param name="PumpAuxCoolingWaterTotalFlowVolume"></param>
        public void PumpAuxCoolingWaterTotalFlowVolume_Writer(String pumpAuxCoolingWaterTotalFlowVolume)
        {
            if (String.IsNullOrEmpty(pumpAuxCoolingWaterTotalFlowVolume))
                return;
        }

        /// <summary>
        /// Global number: 130
        /// API name: TOTAL COOLING WATER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating/eq:coolingHeatingFluid[eq:materialUtilityServiceType="Cooling water"][eq:utilityDemandDeviceType="Total system"]/eq:materialUtilityCondition[etl:propertyType="Total"]/eq:flowVolume
        /// </summary>
        /// <returns></returns>
        public String PumpAuxCoolingWaterTotalFlowVolume_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 86
        /// API name: COOLING WATER PIPING-FITTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeatingFluid/eq:materialUtilityServiceType="Cooling water"]/eqRot:tubeFitting
        /// </summary>
        /// <param name="PumpAuxCoolingWaterTubeFittings"></param>
        public void PumpAuxCoolingWaterTubeFittings_Writer(String pumpAuxCoolingWaterTubeFittings)
        {
            if (String.IsNullOrEmpty(pumpAuxCoolingWaterTubeFittings))
                return;
        }

        /// <summary>
        /// Global number: 86
        /// API name: COOLING WATER PIPING-FITTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeatingFluid/eq:materialUtilityServiceType="Cooling water"]/eqRot:tubeFitting
        /// </summary>
        /// <returns></returns>
        public String PumpAuxCoolingWaterTubeFittings_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 256
        /// API name: HEATING MEDIUM-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeating="Heating"]/eq:coolingHeatingFluid/eq:materialUtilityServiceType
        /// </summary>
        /// <param name="PumpAuxHeatingMedium"></param>
        public void PumpAuxHeatingMedium_Writer(String pumpAuxHeatingMedium)
        {
            if (String.IsNullOrEmpty(pumpAuxHeatingMedium))
                return;
        }

        /// <summary>
        /// Global number: 256
        /// API name: HEATING MEDIUM-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeating="Heating"]/eq:coolingHeatingFluid/eq:materialUtilityServiceType
        /// </summary>
        /// <returns></returns>
        public String PumpAuxHeatingMedium_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 257
        /// API name: HEATING PIPING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeating="Heating"]/eqRot:auxiliaryPipeType
        /// </summary>
        /// <param name="PumpAuxHeatingPipingType"></param>
        public void PumpAuxHeatingPipingType_Writer(String pumpAuxHeatingPipingType)
        {
            if (String.IsNullOrEmpty(pumpAuxHeatingPipingType))
                return;
        }

        /// <summary>
        /// Global number: 257
        /// API name: HEATING PIPING-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:auxiliaryCoolingHeating[eq:coolingHeating="Heating"]/eqRot:auxiliaryPipeType
        /// </summary>
        /// <returns></returns>
        public String PumpAuxHeatingPipingType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 702
        /// API name: ADDITIONAL CENTRAL FLUSH PORT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:chamber/eqRot:isAdditionalFlushPortRequired
        /// </summary>
        /// <param name="SealChamberAddFlushPortRequired"></param>
        public void SealChamberAddFlushPortRequired_Writer(String sealChamberAddFlushPortRequired)
        {
            if (String.IsNullOrEmpty(sealChamberAddFlushPortRequired))
                return;
        }

        /// <summary>
        /// Global number: 702
        /// API name: ADDITIONAL CENTRAL FLUSH PORT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:chamber/eqRot:isAdditionalFlushPortRequired
        /// </summary>
        /// <returns></returns>
        public String SealChamberAddFlushPortRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 255
        /// API name: HEATING JACKET REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:chamber/eqRot:needHeatingJacket
        /// </summary>
        /// <param name="SealChamberHeatingJacketRequired"></param>
        public void SealChamberHeatingJacketRequired_Writer(String sealChamberHeatingJacketRequired)
        {
            if (String.IsNullOrEmpty(sealChamberHeatingJacketRequired))
                return;
        }

        /// <summary>
        /// Global number: 255
        /// API name: HEATING JACKET REQ'D-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:chamber/eqRot:needHeatingJacket
        /// </summary>
        /// <returns></returns>
        public String SealChamberHeatingJacketRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 507
        /// API name: INTERCONNECTING PIPING BY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:flushSystem/eq:pipingProvidedBy
        /// </summary>
        /// <param name="SealFlushSystemPipingProvidedBy"></param>
        public void SealFlushSystemPipingProvidedBy_Writer(String sealFlushSystemPipingProvidedBy)
        {
            if (String.IsNullOrEmpty(sealFlushSystemPipingProvidedBy))
                return;
        }

        /// <summary>
        /// Global number: 507
        /// API name: INTERCONNECTING PIPING BY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:flushSystem/eq:pipingProvidedBy
        /// </summary>
        /// <returns></returns>
        public String SealFlushSystemPipingProvidedBy_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 743
        /// API name: Identify Location on Baseplate
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:sealReservoir/eqRot:locationDescription
        /// </summary>
        /// <param name="SealReservoirBaseplateLocDesc"></param>
        public void SealReservoirBaseplateLocDesc_Writer(String sealReservoirBaseplateLocDesc)
        {
            if (String.IsNullOrEmpty(sealReservoirBaseplateLocDesc))
                return;
        }

        /// <summary>
        /// Global number: 743
        /// API name: Identify Location on Baseplate
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:sealReservoir/eqRot:locationDescription
        /// </summary>
        /// <returns></returns>
        public String SealReservoirBaseplateLocDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 518
        /// API name: SEAL SUPPORT SYSTEM MOUNTED ON PUMP BASEPLATE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:sealReservoir/eqRot:mountReservoirOffBaseplate
        /// </summary>
        /// <param name="SealReservoirMountedOffBaseplate"></param>
        public void SealReservoirMountedOffBaseplate_Writer(String sealReservoirMountedOffBaseplate)
        {
            if (String.IsNullOrEmpty(sealReservoirMountedOffBaseplate))
                return;
        }

        /// <summary>
        /// Global number: 518
        /// API name: SEAL SUPPORT SYSTEM MOUNTED ON PUMP BASEPLATE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:seal/eqRot:sealItem/eqRot:sealReservoir/eqRot:mountReservoirOffBaseplate
        /// </summary>
        /// <returns></returns>
        public String SealReservoirMountedOffBaseplate_Reader()
        {
            return null;
        } 
        #endregion

        #region Page 5
        /// <summary>
        /// Global number: 285
        /// API name: DETAILS OF LIFTING DEVICES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:liftingDeviceDetail
        /// </summary>
        /// <param name="BaseplateLiftingDevice"></param>
        public void BaseplateLiftingDevice_Writer(String baseplateLiftingDevice)
        {
            if (String.IsNullOrEmpty(baseplateLiftingDevice))
                return;
        }

        /// <summary>
        /// Global number: 285
        /// API name: DETAILS OF LIFTING DEVICES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:liftingDeviceDetail
        /// </summary>
        /// <returns></returns>
        public String BaseplateLiftingDevice_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 667
        /// API name: BASEPLATE FINISH COAT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:bulkItemRequirement/eq:surfacePreparationPaint [eq:paintType="Finish coat"]/eq:paintDescription
        /// </summary>
        /// <param name="BaseplatePaintFinishDesc"></param>
        public void BaseplatePaintFinishDesc_Writer(String baseplatePaintFinishDesc)
        {
            if (String.IsNullOrEmpty(baseplatePaintFinishDesc))
                return;
        }

        /// <summary>
        /// Global number: 667
        /// API name: BASEPLATE FINISH COAT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:bulkItemRequirement/eq:surfacePreparationPaint [eq:paintType="Finish coat"]/eq:paintDescription
        /// </summary>
        /// <returns></returns>
        public String BaseplatePaintFinishDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 35
        /// API name: BASEPLATE PRIMER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:bulkItemRequirement/eq:surfacePreparationPaint [eq:paintType="Primer"]/eq:paintDescription
        /// </summary>
        /// <param name="BaseplatePaintPrimerDesc"></param>
        public void BaseplatePaintPrimerDesc_Writer(String baseplatePaintPrimerDesc)
        {
            if (String.IsNullOrEmpty(baseplatePaintPrimerDesc))
                return;
        }

        /// <summary>
        /// Global number: 35
        /// API name: BASEPLATE PRIMER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:bulkItemRequirement/eq:surfacePreparationPaint [eq:paintType="Primer"]/eq:paintDescription
        /// </summary>
        /// <returns></returns>
        public String BaseplatePaintPrimerDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 36
        /// API name: BASEPLATE SURFACE PREPARATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:bulkItemRequirement/eq:surfacePreparationPaint/eq:remark
        /// </summary>
        /// <param name="BaseplateSurfacePrepPaintRemark"></param>
        public void BaseplateSurfacePrepPaintRemark_Writer(String baseplateSurfacePrepPaintRemark)
        {
            if (String.IsNullOrEmpty(baseplateSurfacePrepPaintRemark))
                return;
        }

        /// <summary>
        /// Global number: 36
        /// API name: BASEPLATE SURFACE PREPARATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:bulkItemRequirement/eq:surfacePreparationPaint/eq:remark
        /// </summary>
        /// <returns></returns>
        public String BaseplateSurfacePrepPaintRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 27
        /// API name: W1-BASE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:weight
        /// </summary>
        /// <param name="BaseplateWeight"></param>
        public void BaseplateWeight_Writer(String baseplateWeight)
        {
            if (String.IsNullOrEmpty(baseplateWeight))
                return;
        }

        /// <summary>
        /// Global number: 27
        /// API name: W1-BASE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eq:weight
        /// </summary>
        /// <returns></returns>
        public String BaseplateWeight_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 52
        /// API name: CADMIUM PLATED BOLTS PROHIBITED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:boltStud/eq:isCadmiumProhibited
        /// </summary>
        /// <param name="ConnectionBoltingCadmiumProhibited"></param>
        public void ConnectionBoltingCadmiumProhibited_Writer(String connectionBoltingCadmiumProhibited)
        {
            if (String.IsNullOrEmpty(connectionBoltingCadmiumProhibited))
                return;
        }

        /// <summary>
        /// Global number: 52
        /// API name: CADMIUM PLATED BOLTS PROHIBITED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:boltStud/eq:isCadmiumProhibited
        /// </summary>
        /// <returns></returns>
        public String ConnectionBoltingCadmiumProhibited_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 80
        /// API name: CONNECTION BOLTING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:boltStud/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="ConnectionBoltingConstrMaterial_ConnectionBoltingPaintedRequired"></param>
        public void ConnectionBoltingConstrMaterial_ConnectionBoltingPaintedRequired_Writer(String connectionBoltingConstrMaterial_ConnectionBoltingPaintedRequired)
        {
            if (String.IsNullOrEmpty(connectionBoltingConstrMaterial_ConnectionBoltingPaintedRequired))
                return;
        }

        /// <summary>
        /// Global number: 80
        /// API name: CONNECTION BOLTING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:boltStud/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String ConnectionBoltingConstrMaterial_ConnectionBoltingPaintedRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 79
        /// API name: CONNECTION DESIGN APPROVAL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:review[eq:reviewOrApprovalType="Approval - connection design"]/eq:isRequired
        /// </summary>
        /// <param name="ConnectionDesignApprovalRequired"></param>
        public void ConnectionDesignApprovalRequired_Writer(String connectionDesignApprovalRequired)
        {
            if (String.IsNullOrEmpty(connectionDesignApprovalRequired))
                return;
        }

        /// <summary>
        /// Global number: 79
        /// API name: CONNECTION DESIGN APPROVAL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:review[eq:reviewOrApprovalType="Approval - connection design"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String ConnectionDesignApprovalRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 219
        /// API name: FLANGES REQUIRED IN PLACE OF SOCKET WELD UNIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:useFlangeForSocketWeldUnion
        /// </summary>
        /// <param name="ConnectionUseFlangeForSocketWeldUnion"></param>
        public void ConnectionUseFlangeForSocketWeldUnion_Writer(String connectionUseFlangeForSocketWeldUnion)
        {
            if (String.IsNullOrEmpty(connectionUseFlangeForSocketWeldUnion))
                return;
        }

        /// <summary>
        /// Global number: 219
        /// API name: FLANGES REQUIRED IN PLACE OF SOCKET WELD UNIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:equipmentConnection/eq:useFlangeForSocketWeldUnion
        /// </summary>
        /// <returns></returns>
        public String ConnectionUseFlangeForSocketWeldUnion_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 61
        /// API name: MATERIAL CERTIFICATION REQUIRED-CASING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - casing"]/dx:isRequired
        /// </summary>
        /// <param name="DocCertificateCasingMtrlRequired"></param>
        public void DocCertificateCasingMtrlRequired_Writer(String docCertificateCasingMtrlRequired)
        {
            if (String.IsNullOrEmpty(docCertificateCasingMtrlRequired))
                return;
        }

        /// <summary>
        /// Global number: 61
        /// API name: MATERIAL CERTIFICATION REQUIRED-CASING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - casing"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocCertificateCasingMtrlRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 265
        /// API name: IMPELLER-CERT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - impeller"]/dx:isRequired
        /// </summary>
        /// <param name="DocCertificateImpellerMtrlRequired"></param>
        public void DocCertificateImpellerMtrlRequired_Writer(String docCertificateImpellerMtrlRequired)
        {
            if (String.IsNullOrEmpty(docCertificateImpellerMtrlRequired))
                return;
        }

        /// <summary>
        /// Global number: 265
        /// API name: IMPELLER-CERT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - impeller"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocCertificateImpellerMtrlRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 404
        /// API name: OTHER-CERT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - other"]/dx:documentDescription
        /// </summary>
        /// <param name="DocCertificateOtherMtrlDesc"></param>
        public void DocCertificateOtherMtrlDesc_Writer(String docCertificateOtherMtrlDesc)
        {
            if (String.IsNullOrEmpty(docCertificateOtherMtrlDesc))
                return;
        }

        /// <summary>
        /// Global number: 404
        /// API name: OTHER-CERT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - other"]/dx:documentDescription
        /// </summary>
        /// <returns></returns>
        public String DocCertificateOtherMtrlDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 524
        /// API name: SHAFT-Cert
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - shaft"]/dx:isRequired
        /// </summary>
        /// <param name="DocCertificateShaftMtrlRequired"></param>
        public void DocCertificateShaftMtrlRequired_Writer(String docCertificateShaftMtrlRequired)
        {
            if (String.IsNullOrEmpty(docCertificateShaftMtrlRequired))
                return;
        }

        /// <summary>
        /// Global number: 524
        /// API name: SHAFT-Cert
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:certification="Material - shaft"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocCertificateShaftMtrlRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 711
        /// API name: BEARING LIFE CALCULATIONS REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Bearing system life calculations"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataBearingSysLifeCalcsRequired"></param>
        public void DocDataBearingSysLifeCalcsRequired_Writer(String docDataBearingSysLifeCalcsRequired)
        {
            if (String.IsNullOrEmpty(docDataBearingSysLifeCalcsRequired))
                return;
        }

        /// <summary>
        /// Global number: 711
        /// API name: BEARING LIFE CALCULATIONS REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Bearing system life calculations"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataBearingSysLifeCalcsRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 718
        /// API name: CASING RETIREMENT THICKNESS DRAWING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Casing retirement thickness drawing"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataCasingRetireDrawingRequired"></param>
        public void DocDataCasingRetireDrawingRequired_Writer(String docDataCasingRetireDrawingRequired)
        {
            if (String.IsNullOrEmpty(docDataCasingRetireDrawingRequired))
                return;
        }

        /// <summary>
        /// Global number: 718
        /// API name: CASING RETIREMENT THICKNESS DRAWING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Casing retirement thickness drawing"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataCasingRetireDrawingRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 569
        /// API name: SUBMIT INSPECTION CHECK LIST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Inspection checklist"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataInspectionCheckListRequired"></param>
        public void DocDataInspectionCheckListRequired_Writer(String docDataInspectionCheckListRequired)
        {
            if (String.IsNullOrEmpty(docDataInspectionCheckListRequired))
                return;
        }

        /// <summary>
        /// Global number: 569
        /// API name: SUBMIT INSPECTION CHECK LIST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Inspection checklist"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataInspectionCheckListRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 638
        /// API name: VENDOR TO KEEP REPAIR AND HT RECORDS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Repairs"][dx:isRetained="true"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataRepairsRetainedRequired"></param>
        public void DocDataRepairsRetainedRequired_Writer(String docDataRepairsRetainedRequired)
        {
            if (String.IsNullOrEmpty(docDataRepairsRetainedRequired))
                return;
        }

        /// <summary>
        /// Global number: 638
        /// API name: VENDOR TO KEEP REPAIR AND HT RECORDS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Repairs"][dx:isRetained="true"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataRepairsRetainedRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 640
        /// API name: VENDOR SUBMIT TEST PROCEDURES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Test procedure submission"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataTestProcSubmitRequired"></param>
        public void DocDataTestProcSubmitRequired_Writer(String docDataTestProcSubmitRequired)
        {
            if (String.IsNullOrEmpty(docDataTestProcSubmitRequired))
                return;
        }

        /// <summary>
        /// Global number: 640
        /// API name: VENDOR SUBMIT TEST PROCEDURES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Test procedure submission"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataTestProcSubmitRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 274
        /// API name: INCLUDE PLOTTED VIBRATION SPECTRA-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Vibration spectra"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataVibSpectraRequired"></param>
        public void DocDataVibSpectraRequired_Writer(String docDataVibSpectraRequired)
        {
            if (String.IsNullOrEmpty(docDataVibSpectraRequired))
                return;
        }

        /// <summary>
        /// Global number: 274
        /// API name: INCLUDE PLOTTED VIBRATION SPECTRA-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Vibration spectra"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataVibSpectraRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 665
        /// API name: W1-DRIVER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:weight
        /// </summary>
        /// <param name="DriverWeight"></param>
        public void DriverWeight_Writer(String driverWeight)
        {
            if (String.IsNullOrEmpty(driverWeight))
                return;
        }

        /// <summary>
        /// Global number: 665
        /// API name: W1-DRIVER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:attachedDriver/*/eq:weight
        /// </summary>
        /// <returns></returns>
        public String DriverWeight_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 621
        /// API name: W1-TOTAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:extendedWeight[@weightType="Total"][@weightComponentType="Unit, baseplate, driver"]
        /// </summary>
        /// <param name="ExtendedWeightUnitBaseplateDriver"></param>
        public void ExtendedWeightUnitBaseplateDriver_Writer(String extendedWeightUnitBaseplateDriver)
        {
            if (String.IsNullOrEmpty(extendedWeightUnitBaseplateDriver))
                return;
        }

        /// <summary>
        /// Global number: 621
        /// API name: W1-TOTAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:extendedWeight[@weightType="Total"][@weightComponentType="Unit, baseplate, driver"]
        /// </summary>
        /// <returns></returns>
        public String ExtendedWeightUnitBaseplateDriver_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 666
        /// API name: W1-GEAR
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:gear/eq:weight
        /// </summary>
        /// <param name="GearWeight"></param>
        public void GearWeight_Writer(String gearWeight)
        {
            if (String.IsNullOrEmpty(gearWeight))
                return;
        }

        /// <summary>
        /// Global number: 666
        /// API name: W1-GEAR
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:gear/eq:weight
        /// </summary>
        /// <returns></returns>
        public String GearWeight_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 744
        /// API name: IGNITION HAZARD ASSESSMENT TO EN 13463-1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Ignition hazard"]/eq:isRequired
        /// </summary>
        /// <param name="IgnitionHazardAnalysisRequired"></param>
        public void IgnitionHazardAnalysisRequired_Writer(String ignitionHazardAnalysisRequired)
        {
            if (String.IsNullOrEmpty(ignitionHazardAnalysisRequired))
                return;
        }

        /// <summary>
        /// Global number: 744
        /// API name: IGNITION HAZARD ASSESSMENT TO EN 13463-1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Ignition hazard"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String IgnitionHazardAnalysisRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 189
        /// API name: DYNAMIC BALANCE ROTOR-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Dynamic balance of rotor"]/eq:isRequired
        /// </summary>
        /// <param name="InspectionRotorDynamicBalance"></param>
        public void InspectionRotorDynamicBalance_Writer(String inspectionRotorDynamicBalance)
        {
            if (String.IsNullOrEmpty(inspectionRotorDynamicBalance))
                return;
        }

        /// <summary>
        /// Global number: 189
        /// API name: DYNAMIC BALANCE ROTOR-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Dynamic balance of rotor"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String InspectionRotorDynamicBalance_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 673
        /// API name: INSTALLATION LIST IN PROPOSAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Installation list in proposal"]/dx:isRequired
        /// </summary>
        /// <param name="InstallationListRequired"></param>
        public void InstallationListRequired_Writer(String installationListRequired)
        {
            if (String.IsNullOrEmpty(installationListRequired))
                return;
        }

        /// <summary>
        /// Global number: 673
        /// API name: INSTALLATION LIST IN PROPOSAL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Installation list in proposal"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String InstallationListRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 283
        /// API name: LATERAL ANALYSIS REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Lateral"]/eq:isRequired
        /// </summary>
        /// <param name="LateralAnalysisRequired"></param>
        public void LateralAnalysisRequired_Writer(String lateralAnalysisRequired)
        {
            if (String.IsNullOrEmpty(lateralAnalysisRequired))
                return;
        }

        /// <summary>
        /// Global number: 283
        /// API name: LATERAL ANALYSIS REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Lateral"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String LateralAnalysisRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 100
        /// API name: COORDINATION MEETING REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:meeting[eq:meetingType="Coordination"]/eq:isRequired
        /// </summary>
        /// <param name="MeetingCoordinationRequired"></param>
        public void MeetingCoordinationRequired_Writer(String meetingCoordinationRequired)
        {
            if (String.IsNullOrEmpty(meetingCoordinationRequired))
                return;
        }

        /// <summary>
        /// Global number: 100
        /// API name: COORDINATION MEETING REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:meeting[eq:meetingType="Coordination"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String MeetingCoordinationRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 761
        /// API name: MODAL ANALYSIS REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Modal"]/eq:isRequired
        /// </summary>
        /// <param name="ModalAnalysisRequired"></param>
        public void ModalAnalysisRequired_Writer(String modalAnalysisRequired)
        {
            if (String.IsNullOrEmpty(modalAnalysisRequired))
                return;
        }

        /// <summary>
        /// Global number: 761
        /// API name: MODAL ANALYSIS REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Modal"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String ModalAnalysisRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 442
        /// API name: OUTLINE OF PROCEDURES FOR OPTIONAL TESTS (10.2.5)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Optional test outline"]/dx:isRequired
        /// </summary>
        /// <param name="OptionalTestOutlineRequired"></param>
        public void OptionalTestOutlineRequired_Writer(String optionalTestOutlineRequired)
        {
            if (String.IsNullOrEmpty(optionalTestOutlineRequired))
                return;
        }

        /// <summary>
        /// Global number: 442
        /// API name: OUTLINE OF PROCEDURES FOR OPTIONAL TESTS (10.2.5)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Optional test outline"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String OptionalTestOutlineRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 3
        /// API name: ADDITIONAL DATA REQUIRING 20 YEARS RETENTION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Other"][dx:numberYearsRetention="20"]/dx:isRequired
        /// </summary>
        /// <param name="OtherData20YrRetentionRequired"></param>
        public void OtherData20YrRetentionRequired_Writer(String otherData20YrRetentionRequired)
        {
            if (String.IsNullOrEmpty(otherData20YrRetentionRequired))
                return;
        }

        /// <summary>
        /// Global number: 3
        /// API name: ADDITIONAL DATA REQUIRING 20 YEARS RETENTION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Other"][dx:numberYearsRetention="20"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String OtherData20YrRetentionRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 445
        /// API name: PROGRESS REPORTS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Progress report"]/dx:isRequired
        /// </summary>
        /// <param name="ProgressReportRequired"></param>
        public void ProgressReportRequired_Writer(String progressReportRequired)
        {
            if (String.IsNullOrEmpty(progressReportRequired))
                return;
        }

        /// <summary>
        /// Global number: 445
        /// API name: PROGRESS REPORTS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Progress report"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String ProgressReportRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 272
        /// API name: MAXIMUM DISCHARGE PRESSURE TO INCLUDE-MAX RELATIVE DENSITY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:isMaxOutletPForMaxSpecificGravity
        /// </summary>
        /// <param name="PumpDesignIsMaxOutletPForMaxSG"></param>
        public void PumpDesignIsMaxOutletPForMaxSG_Writer(String pumpDesignIsMaxOutletPForMaxSG)
        {
            if (String.IsNullOrEmpty(pumpDesignIsMaxOutletPForMaxSG))
                return;
        }

        /// <summary>
        /// Global number: 272
        /// API name: MAXIMUM DISCHARGE PRESSURE TO INCLUDE-MAX RELATIVE DENSITY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:isMaxOutletPForMaxSpecificGravity
        /// </summary>
        /// <returns></returns>
        public String PumpDesignIsMaxOutletPForMaxSG_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 273
        /// API name: OPERATION TO TRIP SPEED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:isMaxOutletPForOperationToTripSpeed
        /// </summary>
        /// <param name="PumpDesignIsMaxOutletPForOpTripSpd"></param>
        public void PumpDesignIsMaxOutletPForOpTripSpd_Writer(String pumpDesignIsMaxOutletPForOpTripSpd)
        {
            if (String.IsNullOrEmpty(pumpDesignIsMaxOutletPForOpTripSpd))
                return;
        }

        /// <summary>
        /// Global number: 273
        /// API name: OPERATION TO TRIP SPEED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:isMaxOutletPForOperationToTripSpeed
        /// </summary>
        /// <returns></returns>
        public String PumpDesignIsMaxOutletPForOpTripSpd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 271
        /// API name: MAX DIA. IMPELLERS AND/OR NO OF STAGES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:isMaxOutletPWithMaxImpellerDiameter
        /// </summary>
        /// <param name="PumpDesignIsMaxOutletPMaxImpellerDiam"></param>
        public void PumpDesignIsMaxOutletPMaxImpellerDiam_Writer(String pumpDesignIsMaxOutletPMaxImpellerDiam)
        {
            if (String.IsNullOrEmpty(pumpDesignIsMaxOutletPMaxImpellerDiam))
                return;
        }

        /// <summary>
        /// Global number: 271
        /// API name: MAX DIA. IMPELLERS AND/OR NO OF STAGES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:centrifugalPumpDesign/eqRot:isMaxOutletPWithMaxImpellerDiameter
        /// </summary>
        /// <returns></returns>
        public String PumpDesignIsMaxOutletPMaxImpellerDiam_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 453
        /// API name: PUMP FINISH COAT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint[eq:paintType="Finish coat"]/eq:paintDescription
        /// </summary>
        /// <param name="PumpPaintFinishDesc"></param>
        public void PumpPaintFinishDesc_Writer(String pumpPaintFinishDesc)
        {
            if (String.IsNullOrEmpty(pumpPaintFinishDesc))
                return;
        }

        /// <summary>
        /// Global number: 453
        /// API name: PUMP FINISH COAT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint[eq:paintType="Finish coat"]/eq:paintDescription
        /// </summary>
        /// <returns></returns>
        public String PumpPaintFinishDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 460
        /// API name: PUMP PRIMER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint[eq:paintType="Primer"]/eq:paintDescription
        /// </summary>
        /// <param name="PumpPaintPrimerDesc"></param>
        public void PumpPaintPrimerDesc_Writer(String pumpPaintPrimerDesc)
        {
            if (String.IsNullOrEmpty(pumpPaintPrimerDesc))
                return;
        }

        /// <summary>
        /// Global number: 460
        /// API name: PUMP PRIMER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint[eq:paintType="Primer"]/eq:paintDescription
        /// </summary>
        /// <returns></returns>
        public String PumpPaintPrimerDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 415
        /// API name: MANUFACTURER'S STANDARD-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:paintType
        /// </summary>
        /// <param name="PumpPaintType"></param>
        public void PumpPaintType_Writer(String pumpPaintType)
        {
            if (String.IsNullOrEmpty(pumpPaintType))
                return;
        }

        /// <summary>
        /// Global number: 415
        /// API name: MANUFACTURER'S STANDARD-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:paintType
        /// </summary>
        /// <returns></returns>
        public String PumpPaintType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 416
        /// API name: OTHER (SEE BELOW)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:paintType
        /// </summary>
        /// <param name="PumpPaintTypeOther"></param>
        public void PumpPaintTypeOther_Writer(String pumpPaintTypeOther)
        {
            if (String.IsNullOrEmpty(pumpPaintTypeOther))
                return;
        }

        /// <summary>
        /// Global number: 416
        /// API name: OTHER (SEE BELOW)-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:paintType
        /// </summary>
        /// <returns></returns>
        public String PumpPaintTypeOther_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 456
        /// API name: W1-PUMP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:weight
        /// </summary>
        /// <param name="PumpWeight"></param>
        public void PumpWeight_Writer(String pumpWeight)
        {
            if (String.IsNullOrEmpty(pumpWeight))
                return;
        }

        /// <summary>
        /// Global number: 456
        /// API name: W1-PUMP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:weight
        /// </summary>
        /// <returns></returns>
        public String PumpWeight_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 69
        /// API name: CASTING REPAIR WELD PROCEDURE APPROVAL REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:review[eq:reviewOrApprovalType="Approval - casting repair"]/eq:isRequired
        /// </summary>
        /// <param name="ReviewApprovalCastingRepairRequired"></param>
        public void ReviewApprovalCastingRepairRequired_Writer(String reviewApprovalCastingRepairRequired)
        {
            if (String.IsNullOrEmpty(reviewApprovalCastingRepairRequired))
                return;
        }

        /// <summary>
        /// Global number: 69
        /// API name: CASTING REPAIR WELD PROCEDURE APPROVAL REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:review[eq:reviewOrApprovalType="Approval - casting repair"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String ReviewApprovalCastingRepairRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 124
        /// API name: PERFORMANCE CURVE & DATA APPROVAL PRIOR TO SHIPMENT.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:review[eq:reviewOrApprovalType="Approval - performance curve"]/eq:isRequired
        /// </summary>
        /// <param name="ReviewApprovalPerfCurveRequired"></param>
        public void ReviewApprovalPerfCurveRequired_Writer(String reviewApprovalPerfCurveRequired)
        {
            if (String.IsNullOrEmpty(reviewApprovalPerfCurveRequired))
                return;
        }

        /// <summary>
        /// Global number: 124
        /// API name: PERFORMANCE CURVE & DATA APPROVAL PRIOR TO SHIPMENT.-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:review[eq:reviewOrApprovalType="Approval - performance curve"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String ReviewApprovalPerfCurveRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 408
        /// API name: OUTDOOR STORAGE MORE THAN 6 MONTHS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:outdoor6MonthStorage/eq:isRequired
        /// </summary>
        /// <param name="ShippingStorageOut6Month"></param>
        public void ShippingStorageOut6Month_Writer(String shippingStorageOut6Month)
        {
            if (String.IsNullOrEmpty(shippingStorageOut6Month))
                return;
        }

        /// <summary>
        /// Global number: 408
        /// API name: OUTDOOR STORAGE MORE THAN 6 MONTHS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:outdoor6MonthStorage/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String ShippingStorageOut6Month_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 215
        /// API name: EXPORT BOXING REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:packagingType
        /// </summary>
        /// <param name="ShippingStoragePackagingType_ShippingStorageRemark"></param>
        public void ShippingStoragePackagingType_ShippingStorageRemark_Writer(String shippingStoragePackagingType_ShippingStorageRemark)
        {
            if (String.IsNullOrEmpty(shippingStoragePackagingType_ShippingStorageRemark))
                return;
        }

        /// <summary>
        /// Global number: 215
        /// API name: EXPORT BOXING REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:packagingType
        /// </summary>
        /// <returns></returns>
        public String ShippingStoragePackagingType_ShippingStorageRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 645
        /// API name: Rotor Storage Orientation
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:spareRotorAssembly/eq:storagePackageEquipmentOrientation
        /// </summary>
        /// <param name="ShippingStorageSpareRtrAsmEquipOrient"></param>
        public void ShippingStorageSpareRtrAsmEquipOrient_Writer(String shippingStorageSpareRtrAsmEquipOrient)
        {
            if (String.IsNullOrEmpty(shippingStorageSpareRtrAsmEquipOrient))
                return;
        }

        /// <summary>
        /// Global number: 645
        /// API name: Rotor Storage Orientation
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:spareRotorAssembly/eq:storagePackageEquipmentOrientation
        /// </summary>
        /// <returns></returns>
        public String ShippingStorageSpareRtrAsmEquipOrient_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 371
        /// API name: N2 PURGE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:spareRotorAssembly/eq:hasShippingContainerN2PurgeDesign
        /// </summary>
        /// <param name="ShippingStorageSpareRtrAsmN2Purge"></param>
        public void ShippingStorageSpareRtrAsmN2Purge_Writer(String shippingStorageSpareRtrAsmN2Purge)
        {
            if (String.IsNullOrEmpty(shippingStorageSpareRtrAsmN2Purge))
                return;
        }

        /// <summary>
        /// Global number: 371
        /// API name: N2 PURGE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:spareRotorAssembly/eq:hasShippingContainerN2PurgeDesign
        /// </summary>
        /// <returns></returns>
        public String ShippingStorageSpareRtrAsmN2Purge_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 817
        /// API name: SHIPPING & STORAGE CONTAINER FOR VERT STORAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:spareRotorAssembly/eq:isShippingContainerRequired
        /// </summary>
        /// <param name="ShippingStorageSpareRtrAsmVertContainerReqd"></param>
        public void ShippingStorageSpareRtrAsmVertContainerReqd_Writer(String shippingStorageSpareRtrAsmVertContainerReqd)
        {
            if (String.IsNullOrEmpty(shippingStorageSpareRtrAsmVertContainerReqd))
                return;
        }

        /// <summary>
        /// Global number: 817
        /// API name: SHIPPING & STORAGE CONTAINER FOR VERT STORAGE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:spareRotorAssembly/eq:isShippingContainerRequired
        /// </summary>
        /// <returns></returns>
        public String ShippingStorageSpareRtrAsmVertContainerReqd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 528
        /// API name: SHIPMENT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:shipmentType
        /// </summary>
        /// <param name="ShippingType"></param>
        public void ShippingType_Writer(String shippingType)
        {
            if (String.IsNullOrEmpty(shippingType))
                return;
        }

        /// <summary>
        /// Global number: 528
        /// API name: SHIPMENT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:shippingStorage/eq:shipmentType
        /// </summary>
        /// <returns></returns>
        public String ShippingType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 553
        /// API name: NORMAL MAINTENANCE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:sparePart/eq:needNormalMaintenance
        /// </summary>
        /// <param name="SparePartNeedNormMaintenance"></param>
        public void SparePartNeedNormMaintenance_Writer(String sparePartNeedNormMaintenance)
        {
            if (String.IsNullOrEmpty(sparePartNeedNormMaintenance))
                return;
        }

        /// <summary>
        /// Global number: 553
        /// API name: NORMAL MAINTENANCE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:sparePart/eq:needNormalMaintenance
        /// </summary>
        /// <returns></returns>
        public String SparePartNeedNormMaintenance_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 554
        /// API name: START-UP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:sparePart/eq:needStartup
        /// </summary>
        /// <param name="SparePartNeedStartUp"></param>
        public void SparePartNeedStartUp_Writer(String sparePartNeedStartUp)
        {
            if (String.IsNullOrEmpty(sparePartNeedStartUp))
                return;
        }

        /// <summary>
        /// Global number: 554
        /// API name: START-UP-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:sparePart/eq:needStartup
        /// </summary>
        /// <returns></returns>
        public String SparePartNeedStartUp_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 862
        /// API name: VFD STEADY STATE DAMPED RESPONSE ANALYSIS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Steady-state damped-response"]/eq:isRequired
        /// </summary>
        /// <param name="SteadyStateDampedRespAnalysisRequired"></param>
        public void SteadyStateDampedRespAnalysisRequired_Writer(String steadyStateDampedRespAnalysisRequired)
        {
            if (String.IsNullOrEmpty(steadyStateDampedRespAnalysisRequired))
                return;
        }

        /// <summary>
        /// Global number: 862
        /// API name: VFD STEADY STATE DAMPED RESPONSE ANALYSIS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Steady-state damped-response"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String SteadyStateDampedRespAnalysisRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 464
        /// API name: PUMP SURFACE PREPARATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:remark
        /// </summary>
        /// <param name="SurfacePrepPaintRemark"></param>
        public void SurfacePrepPaintRemark_Writer(String surfacePrepPaintRemark)
        {
            if (String.IsNullOrEmpty(surfacePrepPaintRemark))
                return;
        }

        /// <summary>
        /// Global number: 464
        /// API name: PUMP SURFACE PREPARATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:remark
        /// </summary>
        /// <returns></returns>
        public String SurfacePrepPaintRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 417
        /// API name: SPECIFICATION NO-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:specID
        /// </summary>
        /// <param name="SurfacePrepPaintSpecID"></param>
        public void SurfacePrepPaintSpecID_Writer(String surfacePrepPaintSpecID)
        {
            if (String.IsNullOrEmpty(surfacePrepPaintSpecID))
                return;
        }

        /// <summary>
        /// Global number: 417
        /// API name: SPECIFICATION NO-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:surfacePreparationPaint/eq:specID
        /// </summary>
        /// <returns></returns>
        public String SurfacePrepPaintSpecID_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1746
        /// API name: Equipment to be Included in Auxiliary Tests
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Auxiliary equipment"]/eq:inspectionComponent/eq:description
        /// </summary>
        /// <param name="TestAuxiliaryEquipComponentDesc"></param>
        public void TestAuxiliaryEquipComponentDesc_Writer(String testAuxiliaryEquipComponentDesc)
        {
            if (String.IsNullOrEmpty(testAuxiliaryEquipComponentDesc))
                return;
        }

        /// <summary>
        /// Global number: 1746
        /// API name: Equipment to be Included in Auxiliary Tests
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Auxiliary equipment"]/eq:inspectionComponent/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestAuxiliaryEquipComponentDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 753
        /// API name: LOCATION OF AUXILIARY EQUIPMENT TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Auxiliary equipment"]/eq:testLocation
        /// </summary>
        /// <param name="TestAuxiliaryEquipLocation"></param>
        public void TestAuxiliaryEquipLocation_Writer(String testAuxiliaryEquipLocation)
        {
            if (String.IsNullOrEmpty(testAuxiliaryEquipLocation))
                return;
        }

        /// <summary>
        /// Global number: 753
        /// API name: LOCATION OF AUXILIARY EQUIPMENT TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Auxiliary equipment"]/eq:testLocation
        /// </summary>
        /// <returns></returns>
        public String TestAuxiliaryEquipLocation_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 19
        /// API name: AUXILIARY EQUIPMENT TEST  PER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Auxiliary equipment"]/eq:verificationType
        /// </summary>
        /// <param name="TestAuxiliaryEquipVerificationType"></param>
        public void TestAuxiliaryEquipVerificationType_Writer(String testAuxiliaryEquipVerificationType)
        {
            if (String.IsNullOrEmpty(testAuxiliaryEquipVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 19
        /// API name: AUXILIARY EQUIPMENT TEST  PER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Auxiliary equipment"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestAuxiliaryEquipVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 710
        /// API name: BASEPLATE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Nozzle load - baseplate and pump compliance"]/eq:verificationType
        /// </summary>
        /// <param name="TestBaseplateVerificationType"></param>
        public void TestBaseplateVerificationType_Writer(String testBaseplateVerificationType)
        {
            if (String.IsNullOrEmpty(testBaseplateVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 710
        /// API name: BASEPLATE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Nozzle load - baseplate and pump compliance"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestBaseplateVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 49
        /// API name: BRG HSG RESONANCE TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Bearing housing natural frequency"]/eq:verificationType
        /// </summary>
        /// <param name="TestBearingHseResonanceVerificationType"></param>
        public void TestBearingHseResonanceVerificationType_Writer(String testBearingHseResonanceVerificationType)
        {
            if (String.IsNullOrEmpty(testBearingHseResonanceVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 49
        /// API name: BRG HSG RESONANCE TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Bearing housing natural frequency"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestBearingHseResonanceVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 66
        /// API name: CASTINGS-LIQUID PENETRANT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Liquid penetrant"]/eq:isRequired
        /// </summary>
        /// <param name="TestCastingLiquidPenRequired"></param>
        public void TestCastingLiquidPenRequired_Writer(String testCastingLiquidPenRequired)
        {
            if (String.IsNullOrEmpty(testCastingLiquidPenRequired))
                return;
        }

        /// <summary>
        /// Global number: 66
        /// API name: CASTINGS-LIQUID PENETRANT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Liquid penetrant"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestCastingLiquidPenRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 67
        /// API name: INSPECTION REQUIRED FOR CASTINGS-MAG PARTICLE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Magnetic particle"]/eq:isRequired
        /// </summary>
        /// <param name="TestCastingMagPartRequired"></param>
        public void TestCastingMagPartRequired_Writer(String testCastingMagPartRequired)
        {
            if (String.IsNullOrEmpty(testCastingMagPartRequired))
                return;
        }

        /// <summary>
        /// Global number: 67
        /// API name: INSPECTION REQUIRED FOR CASTINGS-MAG PARTICLE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Magnetic particle"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestCastingMagPartRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 68
        /// API name: CASTINGS-RADIOGRAPHY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Radiographic"]/eq:isRequired
        /// </summary>
        /// <param name="TestCastingRadiographicRequired"></param>
        public void TestCastingRadiographicRequired_Writer(String testCastingRadiographicRequired)
        {
            if (String.IsNullOrEmpty(testCastingRadiographicRequired))
                return;
        }

        /// <summary>
        /// Global number: 68
        /// API name: CASTINGS-RADIOGRAPHY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Radiographic"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestCastingRadiographicRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 70
        /// API name: CASTINGS-ULTRASONIC
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Ultrasonic"]/eq:isRequired
        /// </summary>
        /// <param name="TestCastingUltrasonicRequired"></param>
        public void TestCastingUltrasonicRequired_Writer(String testCastingUltrasonicRequired)
        {
            if (String.IsNullOrEmpty(testCastingUltrasonicRequired))
                return;
        }

        /// <summary>
        /// Global number: 70
        /// API name: CASTINGS-ULTRASONIC
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Casting"][eqRot:pumpInspectionTestType="Ultrasonic"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestCastingUltrasonicRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 487
        /// API name: REMOVE CASING AFTER TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Charpy Impact"][eqRot:dismantleInspectAfterTest="true"]/eq:verificationType
        /// </summary>
        /// <param name="TestCharpyImpactPostTestDismantleInspect"></param>
        public void TestCharpyImpactPostTestDismantleInspect_Writer(String testCharpyImpactPostTestDismantleInspect)
        {
            if (String.IsNullOrEmpty(testCharpyImpactPostTestDismantleInspect))
                return;
        }

        /// <summary>
        /// Global number: 487
        /// API name: REMOVE CASING AFTER TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Charpy Impact"][eqRot:dismantleInspectAfterTest="true"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestCharpyImpactPostTestDismantleInspect_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 263
        /// API name: IMPACT TEST-PER ASME SECTION VIII
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Charpy Impact"]/eqRot:pumpTestStandard
        /// </summary>
        /// <param name="TestCharpyImpactTestStandard"></param>
        public void TestCharpyImpactTestStandard_Writer(String testCharpyImpactTestStandard)
        {
            if (String.IsNullOrEmpty(testCharpyImpactTestStandard))
                return;
        }

        /// <summary>
        /// Global number: 263
        /// API name: IMPACT TEST-PER ASME SECTION VIII
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Charpy Impact"]/eqRot:pumpTestStandard
        /// </summary>
        /// <returns></returns>
        public String TestCharpyImpactTestStandard_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 264
        /// API name: IMPACT TEST-PER EN 13445
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Charpy Impact"]/eq:verificationType
        /// </summary>
        /// <param name="TestCharpyImpactVerificationType"></param>
        public void TestCharpyImpactVerificationType_Writer(String testCharpyImpactVerificationType)
        {
            if (String.IsNullOrEmpty(testCharpyImpactVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 264
        /// API name: IMPACT TEST-PER EN 13445
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Charpy Impact"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestCharpyImpactVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 754
        /// API name: LOCATION OF CLEANLINESS INSPECTION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Cleanliness before final assembly"]/eq:testLocation
        /// </summary>
        /// <param name="TestCleanBeforeFinalAsmLocation"></param>
        public void TestCleanBeforeFinalAsmLocation_Writer(String testCleanBeforeFinalAsmLocation)
        {
            if (String.IsNullOrEmpty(testCleanBeforeFinalAsmLocation))
                return;
        }

        /// <summary>
        /// Global number: 754
        /// API name: LOCATION OF CLEANLINESS INSPECTION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Cleanliness before final assembly"]/eq:testLocation
        /// </summary>
        /// <returns></returns>
        public String TestCleanBeforeFinalAsmLocation_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 73
        /// API name: CLEANLINESS PRIOR TO FINAL ASSEMBLY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Cleanliness before final assembly"]/eq:verificationType
        /// </summary>
        /// <param name="TestCleanBeforeFinalAsmVerificationType"></param>
        public void TestCleanBeforeFinalAsmVerificationType_Writer(String testCleanBeforeFinalAsmVerificationType)
        {
            if (String.IsNullOrEmpty(testCleanBeforeFinalAsmVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 73
        /// API name: CLEANLINESS PRIOR TO FINAL ASSEMBLY-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Cleanliness before final assembly"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestCleanBeforeFinalAsmVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 78
        /// API name: COMPLETE UNIT TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Complete unit"]/eq:verificationType
        /// </summary>
        /// <param name="TestCompleteUnitVerificationType"></param>
        public void TestCompleteUnitVerificationType_Writer(String testCompleteUnitVerificationType)
        {
            if (String.IsNullOrEmpty(testCompleteUnitVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 78
        /// API name: COMPLETE UNIT TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Complete unit"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestCompleteUnitVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 81
        /// API name: CONNECTION WELDS-LIQUID PENETRANT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Liquid penetrant"]/eq:isRequired
        /// </summary>
        /// <param name="TestConnWeldLiquidPenRequired"></param>
        public void TestConnWeldLiquidPenRequired_Writer(String testConnWeldLiquidPenRequired)
        {
            if (String.IsNullOrEmpty(testConnWeldLiquidPenRequired))
                return;
        }

        /// <summary>
        /// Global number: 81
        /// API name: CONNECTION WELDS-LIQUID PENETRANT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Liquid penetrant"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestConnWeldLiquidPenRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 82
        /// API name: INSPECTION REQUIRED FOR CONNECTION WELDS-MAG PARTICLE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Magnetic particle"]/eq:isRequired
        /// </summary>
        /// <param name="TestConnWeldMagPartRequired"></param>
        public void TestConnWeldMagPartRequired_Writer(String testConnWeldMagPartRequired)
        {
            if (String.IsNullOrEmpty(testConnWeldMagPartRequired))
                return;
        }

        /// <summary>
        /// Global number: 82
        /// API name: INSPECTION REQUIRED FOR CONNECTION WELDS-MAG PARTICLE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Magnetic particle"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestConnWeldMagPartRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 83
        /// API name: CONNECTION WELDS-RADIOGRAPHY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Radiographic"]/eq:isRequired
        /// </summary>
        /// <param name="TestConnWeldRadiographicRequired"></param>
        public void TestConnWeldRadiographicRequired_Writer(String testConnWeldRadiographicRequired)
        {
            if (String.IsNullOrEmpty(testConnWeldRadiographicRequired))
                return;
        }

        /// <summary>
        /// Global number: 83
        /// API name: CONNECTION WELDS-RADIOGRAPHY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Radiographic"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestConnWeldRadiographicRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 84
        /// API name: CONNECTION WELDS-ULTRASONIC
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Ultrasonic"]/eq:isRequired
        /// </summary>
        /// <param name="TestConnWeldUltrasonicRequired"></param>
        public void TestConnWeldUltrasonicRequired_Writer(String testConnWeldUltrasonicRequired)
        {
            if (String.IsNullOrEmpty(testConnWeldUltrasonicRequired))
                return;
        }

        /// <summary>
        /// Global number: 84
        /// API name: CONNECTION WELDS-ULTRASONIC
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:inspectionComponent/eq:inspectionComponentType="Connection welds"][eqRot:pumpInspectionTestType="Ultrasonic"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestConnWeldUltrasonicRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 101
        /// API name: CHECK FOR CO-PLANAR  MOUNTING PAD SURFACES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Co-planar mounting pad surfaces"]/eq:verificationType
        /// </summary>
        /// <param name="TestCoPlanarMntPadSurfVerificationType"></param>
        public void TestCoPlanarMntPadSurfVerificationType_Writer(String testCoPlanarMntPadSurfVerificationType)
        {
            if (String.IsNullOrEmpty(testCoPlanarMntPadSurfVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 101
        /// API name: CHECK FOR CO-PLANAR  MOUNTING PAD SURFACES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Co-planar mounting pad surfaces"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestCoPlanarMntPadSurfVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 250
        /// API name: HARDNESS TEST REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hardness"]/eq:description
        /// </summary>
        /// <param name="TestHardnessTestDesc"></param>
        public void TestHardnessTestDesc_Writer(String testHardnessTestDesc)
        {
            if (String.IsNullOrEmpty(testHardnessTestDesc))
                return;
        }

        /// <summary>
        /// Global number: 250
        /// API name: HARDNESS TEST REQUIRED-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hardness"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestHardnessTestDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 276
        /// API name: REMOVE / INSPECT HYDRODYNAMIC BEARINGS AFTER TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Inspect hydrodynamic bearings after test"]/eq:verificationType
        /// </summary>
        /// <param name="TestHydroBearingAfterTestVerificationType"></param>
        public void TestHydroBearingAfterTestVerificationType_Writer(String testHydroBearingAfterTestVerificationType)
        {
            if (String.IsNullOrEmpty(testHydroBearingAfterTestVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 276
        /// API name: REMOVE / INSPECT HYDRODYNAMIC BEARINGS AFTER TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Inspect hydrodynamic bearings after test"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestHydroBearingAfterTestVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 260
        /// API name: HYDROSTATIC TEST OF BOWLS & COLUMN-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hydrostatic test of bowls and column"]/eq:verificationType
        /// </summary>
        /// <param name="TestHydrostaticBowlColumnVerificationType"></param>
        public void TestHydrostaticBowlColumnVerificationType_Writer(String testHydrostaticBowlColumnVerificationType)
        {
            if (String.IsNullOrEmpty(testHydrostaticBowlColumnVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 260
        /// API name: HYDROSTATIC TEST OF BOWLS & COLUMN-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hydrostatic test of bowls and column"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestHydrostaticBowlColumnVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 261
        /// API name: HYDROSTATIC -
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hydrostatic"]/eq:verificationType
        /// </summary>
        /// <param name="TestHydrostaticVerificationType"></param>
        public void TestHydrostaticVerificationType_Writer(String testHydrostaticVerificationType)
        {
            if (String.IsNullOrEmpty(testHydrostaticVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 261
        /// API name: HYDROSTATIC -
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Hydrostatic"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestHydrostaticVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 530
        /// API name: SHOP INSPECTION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:testLocation="In shop"][eqRot:pumpInspectionTestType="Unspecified"]/eq:isRequired
        /// </summary>
        /// <param name="TestInShopUnspecRequired"></param>
        public void TestInShopUnspecRequired_Writer(String testInShopUnspecRequired)
        {
            if (String.IsNullOrEmpty(testInShopUnspecRequired))
                return;
        }

        /// <summary>
        /// Global number: 530
        /// API name: SHOP INSPECTION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eq:testLocation="In shop"][eqRot:pumpInspectionTestType="Unspecified"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestInShopUnspecRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 337
        /// API name: 4 HR. MECH RUN AFTER  OIL TEMP STABLE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Mechanical run after oil temperature stable"]/eq:verificationType
        /// </summary>
        /// <param name="TestMechRun4hrOilTStableVerificationType"></param>
        public void TestMechRun4hrOilTStableVerificationType_Writer(String testMechRun4hrOilTStableVerificationType)
        {
            if (String.IsNullOrEmpty(testMechRun4hrOilTStableVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 337
        /// API name: 4 HR. MECH RUN AFTER  OIL TEMP STABLE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Mechanical run after oil temperature stable"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestMechRun4hrOilTStableVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 338
        /// API name: MECHANICAL RUN TEST UNTIL  OIL TEMP STABLE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Mechanical run until oil temperature stable"]/eq:verificationType
        /// </summary>
        /// <param name="TestMechRunTilOilTStableVerificationType"></param>
        public void TestMechRunTilOilTStableVerificationType_Writer(String testMechRunTilOilTStableVerificationType)
        {
            if (String.IsNullOrEmpty(testMechRunTilOilTStableVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 338
        /// API name: MECHANICAL RUN TEST UNTIL  OIL TEMP STABLE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Mechanical run until oil temperature stable"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestMechRunTilOilTStableVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 546
        /// API name: SOUND LEVEL TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Noise"]/eq:verificationType
        /// </summary>
        /// <param name="TestNoiseVerificationType"></param>
        public void TestNoiseVerificationType_Writer(String testNoiseVerificationType)
        {
            if (String.IsNullOrEmpty(testNoiseVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 546
        /// API name: SOUND LEVEL TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Noise"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestNoiseVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 379
        /// API name: NOZZLE LOAD TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Nozzle load"]/eq:verificationType
        /// </summary>
        /// <param name="TestNozzleLoadVerificationType"></param>
        public void TestNozzleLoadVerificationType_Writer(String testNozzleLoadVerificationType)
        {
            if (String.IsNullOrEmpty(testNozzleLoadVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 379
        /// API name: NOZZLE LOAD TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Nozzle load"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestNozzleLoadVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 852
        /// API name: TEST NPSHA LIMITED TO 110% SITE NPSHA
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:maxTestNPSHARequired
        /// </summary>
        /// <param name="TestNPSHAMax110SiteRequired"></param>
        public void TestNPSHAMax110SiteRequired_Writer(String testNPSHAMax110SiteRequired)
        {
            if (String.IsNullOrEmpty(testNPSHAMax110SiteRequired))
                return;
        }

        /// <summary>
        /// Global number: 852
        /// API name: TEST NPSHA LIMITED TO 110% SITE NPSHA
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:maxTestNPSHARequired
        /// </summary>
        /// <returns></returns>
        public String TestNPSHAMax110SiteRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 788
        /// API name: NPSH-1ST STG ONLY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="NPSHR - first stage only"]/eq:verificationType
        /// </summary>
        /// <param name="TestNPSHRFirstStageVerificationType"></param>
        public void TestNPSHRFirstStageVerificationType_Writer(String testNPSHRFirstStageVerificationType)
        {
            if (String.IsNullOrEmpty(testNPSHRFirstStageVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 788
        /// API name: NPSH-1ST STG ONLY
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="NPSHR - first stage only"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestNPSHRFirstStageVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 787
        /// API name: NPSH TESTING TO HI 1.6 OR ISO 9906
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="NPSHR"][eqRot:pumpTestStandard="ISO 9906"]/eq:verificationType
        /// </summary>
        /// <param name="TestNPSHRISO9906VerificationType"></param>
        public void TestNPSHRISO9906VerificationType_Writer(String testNPSHRISO9906VerificationType)
        {
            if (String.IsNullOrEmpty(testNPSHRISO9906VerificationType))
                return;
        }

        /// <summary>
        /// Global number: 787
        /// API name: NPSH TESTING TO HI 1.6 OR ISO 9906
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="NPSHR"][eqRot:pumpTestStandard="ISO 9906"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestNPSHRISO9906VerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 387
        /// API name: NPSH-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="NPSHR"]/eq:verificationType
        /// </summary>
        /// <param name="TestNPSHRVerificationType"></param>
        public void TestNPSHRVerificationType_Writer(String testNPSHRVerificationType)
        {
            if (String.IsNullOrEmpty(testNPSHRVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 387
        /// API name: NPSH-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="NPSHR"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestNPSHRVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 424
        /// API name: TEST TOLERANCES TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:pumpPerformanceTestClass
        /// </summary>
        /// <param name="TestPerfClass"></param>
        public void TestPerfClass_Writer(String testPerfClass)
        {
            if (String.IsNullOrEmpty(testPerfClass))
                return;
        }

        /// <summary>
        /// Global number: 424
        /// API name: TEST TOLERANCES TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:pumpPerformanceTestClass
        /// </summary>
        /// <returns></returns>
        public String TestPerfClass_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 797
        /// API name: PMI TESTING REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Positive Material Identification (PMI)"]/eq:isRequired
        /// </summary>
        /// <param name="TestPMIIsRequired"></param>
        public void TestPMIIsRequired_Writer(String testPMIIsRequired)
        {
            if (String.IsNullOrEmpty(testPMIIsRequired))
                return;
        }

        /// <summary>
        /// Global number: 797
        /// API name: PMI TESTING REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Positive Material Identification (PMI)"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestPMIIsRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 725
        /// API name: COMPONENTS TO BE TESTED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Positive Material Identification (PMI)"]/eq:inspectionComponent/eq:description
        /// </summary>
        /// <param name="TestPMITestComponentDesc"></param>
        public void TestPMITestComponentDesc_Writer(String testPMITestComponentDesc)
        {
            if (String.IsNullOrEmpty(testPMITestComponentDesc))
                return;
        }

        /// <summary>
        /// Global number: 725
        /// API name: COMPONENTS TO BE TESTED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Positive Material Identification (PMI)"]/eq:inspectionComponent/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestPMITestComponentDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 850
        /// API name: TEST DATA POINTS TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:pumpTestMethodStandard
        /// </summary>
        /// <param name="TestPumpPerfMethodStandard"></param>
        public void TestPumpPerfMethodStandard_Writer(String testPumpPerfMethodStandard)
        {
            if (String.IsNullOrEmpty(testPumpPerfMethodStandard))
                return;
        }

        /// <summary>
        /// Global number: 850
        /// API name: TEST DATA POINTS TO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:pumpTestMethodStandard
        /// </summary>
        /// <returns></returns>
        public String TestPumpPerfMethodStandard_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 851
        /// API name: TEST IN COMPLIANCE WITH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:pumpTestStandard
        /// </summary>
        /// <param name="TestPumpPerfStandard"></param>
        public void TestPumpPerfStandard_Writer(String testPumpPerfStandard)
        {
            if (String.IsNullOrEmpty(testPumpPerfStandard))
                return;
        }

        /// <summary>
        /// Global number: 851
        /// API name: TEST IN COMPLIANCE WITH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eqRot:pumpTestStandard
        /// </summary>
        /// <returns></returns>
        public String TestPumpPerfStandard_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 425
        /// API name: PERFORMANCE TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eq:verificationType
        /// </summary>
        /// <param name="TestPumpPerfVerificationType"></param>
        public void TestPumpPerfVerificationType_Writer(String testPumpPerfVerificationType)
        {
            if (String.IsNullOrEmpty(testPumpPerfVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 425
        /// API name: PERFORMANCE TEST-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestPumpPerfVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 812
        /// API name: RESIDUAL UNBALANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Residual unbalance"]/eq:isRequired
        /// </summary>
        /// <param name="TestResidualUnbIsRequired"></param>
        public void TestResidualUnbIsRequired_Writer(String testResidualUnbIsRequired)
        {
            if (String.IsNullOrEmpty(testResidualUnbIsRequired))
                return;
        }

        /// <summary>
        /// Global number: 812
        /// API name: RESIDUAL UNBALANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Residual unbalance"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestResidualUnbIsRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 830
        /// API name: STRUCTURAL RESONANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Resonance"]/eq:verificationType
        /// </summary>
        /// <param name="TestResonanceVerificationType"></param>
        public void TestResonanceVerificationType_Writer(String testResonanceVerificationType)
        {
            if (String.IsNullOrEmpty(testResonanceVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 830
        /// API name: STRUCTURAL RESONANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Resonance"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestResonanceVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 490
        /// API name: RETEST REQUIRED AFTER FINAL HEAD ADJUSTMENT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Retest after final head adjustment"]/eq:verificationType
        /// </summary>
        /// <param name="TestRetestFinalHeadAdjVerificationType"></param>
        public void TestRetestFinalHeadAdjVerificationType_Writer(String testRetestFinalHeadAdjVerificationType)
        {
            if (String.IsNullOrEmpty(testRetestFinalHeadAdjVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 490
        /// API name: RETEST REQUIRED AFTER FINAL HEAD ADJUSTMENT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Retest after final head adjustment"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestRetestFinalHeadAdjVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 512
        /// API name: RETEST ON SEAL LEAKAGE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Retest on seal leakage"]/eq:verificationType
        /// </summary>
        /// <param name="TestRetestOnSealLeakVerificationType"></param>
        public void TestRetestOnSealLeakVerificationType_Writer(String testRetestOnSealLeakVerificationType)
        {
            if (String.IsNullOrEmpty(testRetestOnSealLeakVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 512
        /// API name: RETEST ON SEAL LEAKAGE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Retest on seal leakage"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestRetestOnSealLeakVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 570
        /// API name: TEST WITH SUBSTITUTE SEAL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Substitute seal"]/eq:verificationType
        /// </summary>
        /// <param name="TestSubSealTestVerificationType"></param>
        public void TestSubSealTestVerificationType_Writer(String testSubSealTestVerificationType)
        {
            if (String.IsNullOrEmpty(testSubSealTestVerificationType))
                return;
        }

        /// <summary>
        /// Global number: 570
        /// API name: TEST WITH SUBSTITUTE SEAL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Substitute seal"]/eq:verificationType
        /// </summary>
        /// <returns></returns>
        public String TestSubSealTestVerificationType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1
        /// API name: Additional Subsurface Exam-FOR
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Subsurface"]/eq:inspectionComponent/eq:inspectionComponentType
        /// </summary>
        /// <param name="TestSubsurfaceComponentType"></param>
        public void TestSubsurfaceComponentType_Writer(String testSubsurfaceComponentType)
        {
            if (String.IsNullOrEmpty(testSubsurfaceComponentType))
                return;
        }

        /// <summary>
        /// Global number: 1
        /// API name: Additional Subsurface Exam-FOR
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Subsurface"]/eq:inspectionComponent/eq:inspectionComponentType
        /// </summary>
        /// <returns></returns>
        public String TestSubsurfaceComponentType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 678
        /// API name: ADDITIONAL SUBSURFACE EXAMINATION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Subsurface"]/eq:isRequired
        /// </summary>
        /// <param name="TestSubsurfaceIsRequired"></param>
        public void TestSubsurfaceIsRequired_Writer(String testSubsurfaceIsRequired)
        {
            if (String.IsNullOrEmpty(testSubsurfaceIsRequired))
                return;
        }

        /// <summary>
        /// Global number: 678
        /// API name: ADDITIONAL SUBSURFACE EXAMINATION
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Subsurface"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestSubsurfaceIsRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 2
        /// API name: Additional Subsurface Exam-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Subsurface"]/eq:description
        /// </summary>
        /// <param name="TestSubsurfaceTestDesc"></param>
        public void TestSubsurfaceTestDesc_Writer(String testSubsurfaceTestDesc)
        {
            if (String.IsNullOrEmpty(testSubsurfaceTestDesc))
                return;
        }

        /// <summary>
        /// Global number: 2
        /// API name: Additional Subsurface Exam-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Subsurface"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestSubsurfaceTestDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 785
        /// API name: NOTIFICATION OF SUCCESSFUL SHOP PERFORMANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eq:testSuccessNotificationRequired
        /// </summary>
        /// <param name="TestSuccessNotificRequired"></param>
        public void TestSuccessNotificRequired_Writer(String testSuccessNotificRequired)
        {
            if (String.IsNullOrEmpty(testSuccessNotificRequired))
                return;
        }

        /// <summary>
        /// Global number: 785
        /// API name: NOTIFICATION OF SUCCESSFUL SHOP PERFORMANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Performance rating"]/eq:testSuccessNotificationRequired
        /// </summary>
        /// <returns></returns>
        public String TestSuccessNotificRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 618
        /// API name: TORSIONAL ANALYSIS / REPORT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Torsional analysis"]/dx:isRequired
        /// </summary>
        /// <param name="TorsionalAnalysisReportRequired"></param>
        public void TorsionalAnalysisReportRequired_Writer(String torsionalAnalysisReportRequired)
        {
            if (String.IsNullOrEmpty(torsionalAnalysisReportRequired))
                return;
        }

        /// <summary>
        /// Global number: 618
        /// API name: TORSIONAL ANALYSIS / REPORT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Torsional analysis"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String TorsionalAnalysisReportRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 855
        /// API name: TRANSIENT TORSIONAL RESPONSE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Torsional - transient"]/eq:isRequired
        /// </summary>
        /// <param name="TorsionalTransientAnalysisRequired"></param>
        public void TorsionalTransientAnalysisRequired_Writer(String torsionalTransientAnalysisRequired)
        {
            if (String.IsNullOrEmpty(torsionalTransientAnalysisRequired))
                return;
        }

        /// <summary>
        /// Global number: 855
        /// API name: TRANSIENT TORSIONAL RESPONSE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Torsional - transient"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TorsionalTransientAnalysisRequired_Reader()
        {
            return null;
        } 
        #endregion

        #region Page 6
        /// <summary>
        /// Global number: 829
        /// API name: STRUCTURAL ANALYSIS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Structural"]/eq:isRequired
        /// </summary>
        /// <param name="StructuralAnalysisRequired"></param>
        public void StructuralAnalysisRequired_Writer(String structuralAnalysisRequired)
        {
            if (String.IsNullOrEmpty(structuralAnalysisRequired))
                return;
        }

        /// <summary>
        /// Global number: 829
        /// API name: STRUCTURAL ANALYSIS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eq:analysis[eq:analysisType="Structural"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String StructuralAnalysisRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 813
        /// API name: RESONANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Resonance"]/eq:isRequired
        /// </summary>
        /// <param name="TestResonanceRequired"></param>
        public void TestResonanceRequired_Writer(String testResonanceRequired)
        {
            if (String.IsNullOrEmpty(testResonanceRequired))
                return;
        }

        /// <summary>
        /// Global number: 813
        /// API name: RESONANCE TEST
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Resonance"]/eq:isRequired
        /// </summary>
        /// <returns></returns>
        public String TestResonanceRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 833
        /// API name: SUMP-BELLMOUTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bellmouthMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpBellmouthMaterialName"></param>
        public void VertPumpBellmouthMaterialName_Writer(String vertPumpBellmouthMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpBellmouthMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 833
        /// API name: SUMP-BELLMOUTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bellmouthMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpBellmouthMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 834
        /// API name: SUMP-BOWL BEARING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:bearingMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpBowlBearingMaterialName"></param>
        public void VertPumpBowlBearingMaterialName_Writer(String vertPumpBowlBearingMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpBowlBearingMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 834
        /// API name: SUMP-BOWL BEARING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:bearingMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpBowlBearingMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 714
        /// API name: BOWL HEAD CALCULATION REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:isHeadCalculationRequired
        /// </summary>
        /// <param name="VertPumpBowlHeadCalcReq"></param>
        public void VertPumpBowlHeadCalcReq_Writer(String vertPumpBowlHeadCalcReq)
        {
            if (String.IsNullOrEmpty(vertPumpBowlHeadCalcReq))
                return;
        }

        /// <summary>
        /// Global number: 714
        /// API name: BOWL HEAD CALCULATION REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:isHeadCalculationRequired
        /// </summary>
        /// <returns></returns>
        public String VertPumpBowlHeadCalcReq_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 715
        /// API name: BOWL-HYDRO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:hydrostaticTestP
        /// </summary>
        /// <param name="VertPumpBowlHydroTestP"></param>
        public void VertPumpBowlHydroTestP_Writer(String vertPumpBowlHydroTestP)
        {
            if (String.IsNullOrEmpty(vertPumpBowlHydroTestP))
                return;
        }

        /// <summary>
        /// Global number: 715
        /// API name: BOWL-HYDRO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:hydrostaticTestP
        /// </summary>
        /// <returns></returns>
        public String VertPumpBowlHydroTestP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 716
        /// API name: BOWL-MAWP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:mawp
        /// </summary>
        /// <param name="VertPumpBowlMAWP"></param>
        public void VertPumpBowlMAWP_Writer(String vertPumpBowlMAWP)
        {
            if (String.IsNullOrEmpty(vertPumpBowlMAWP))
                return;
        }

        /// <summary>
        /// Global number: 716
        /// API name: BOWL-MAWP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:mawp
        /// </summary>
        /// <returns></returns>
        public String VertPumpBowlMAWP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 835
        /// API name: SUMP-BOWL SHAFT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:shaftMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpBowlShaftMaterialName"></param>
        public void VertPumpBowlShaftMaterialName_Writer(String vertPumpBowlShaftMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpBowlShaftMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 835
        /// API name: SUMP-BOWL SHAFT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:bowl/eqRot:shaftMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpBowlShaftMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 142
        /// API name: C.L. OF DISCHARGE-3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:centerLineOfDischargeLevel
        /// </summary>
        /// <param name="VertPumpCLDischarge"></param>
        public void VertPumpCLDischarge_Writer(String vertPumpCLDischarge)
        {
            if (String.IsNullOrEmpty(vertPumpCLDischarge))
                return;
        }

        /// <summary>
        /// Global number: 142
        /// API name: C.L. OF DISCHARGE-3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:centerLineOfDischargeLevel
        /// </summary>
        /// <returns></returns>
        public String VertPumpCLDischarge_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 75
        /// API name: COLUMN PIPE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:columnPipeConnectionType
        /// </summary>
        /// <param name="VertPumpColumnPipeConnectionType"></param>
        public void VertPumpColumnPipeConnectionType_Writer(String vertPumpColumnPipeConnectionType)
        {
            if (String.IsNullOrEmpty(vertPumpColumnPipeConnectionType))
                return;
        }

        /// <summary>
        /// Global number: 75
        /// API name: COLUMN PIPE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:columnPipeConnectionType
        /// </summary>
        /// <returns></returns>
        public String VertPumpColumnPipeConnectionType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 644
        /// API name: COLUMN PIPE-DIAMETER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:shape/etl:diameter
        /// </summary>
        /// <param name="VertPumpColumnPipeDiam"></param>
        public void VertPumpColumnPipeDiam_Writer(String vertPumpColumnPipeDiam)
        {
            if (String.IsNullOrEmpty(vertPumpColumnPipeDiam))
                return;
        }

        /// <summary>
        /// Global number: 644
        /// API name: COLUMN PIPE-DIAMETER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:shape/etl:diameter
        /// </summary>
        /// <returns></returns>
        public String VertPumpColumnPipeDiam_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 720
        /// API name: COLUMN PIPE-HYDRO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:hydrostaticTestP
        /// </summary>
        /// <param name="VertPumpColumnPipeHydroTestP"></param>
        public void VertPumpColumnPipeHydroTestP_Writer(String vertPumpColumnPipeHydroTestP)
        {
            if (String.IsNullOrEmpty(vertPumpColumnPipeHydroTestP))
                return;
        }

        /// <summary>
        /// Global number: 720
        /// API name: COLUMN PIPE-HYDRO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:hydrostaticTestP
        /// </summary>
        /// <returns></returns>
        public String VertPumpColumnPipeHydroTestP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 76
        /// API name: COLUMN PIPE-LENGTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:shape/etl:length
        /// </summary>
        /// <param name="VertPumpColumnPipeL"></param>
        public void VertPumpColumnPipeL_Writer(String vertPumpColumnPipeL)
        {
            if (String.IsNullOrEmpty(vertPumpColumnPipeL))
                return;
        }

        /// <summary>
        /// Global number: 76
        /// API name: COLUMN PIPE-LENGTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:shape/etl:length
        /// </summary>
        /// <returns></returns>
        public String VertPumpColumnPipeL_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 721
        /// API name: COLUMN PIPE-MAWP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:mawp
        /// </summary>
        /// <param name="VertPumpColumnPipeMAWP"></param>
        public void VertPumpColumnPipeMAWP_Writer(String vertPumpColumnPipeMAWP)
        {
            if (String.IsNullOrEmpty(vertPumpColumnPipeMAWP))
                return;
        }

        /// <summary>
        /// Global number: 721
        /// API name: COLUMN PIPE-MAWP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:mawp
        /// </summary>
        /// <returns></returns>
        public String VertPumpColumnPipeMAWP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 722
        /// API name: COLUMN PIPE-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:number
        /// </summary>
        /// <param name="VertPumpColumnPipeNumber"></param>
        public void VertPumpColumnPipeNumber_Writer(String vertPumpColumnPipeNumber)
        {
            if (String.IsNullOrEmpty(vertPumpColumnPipeNumber))
                return;
        }

        /// <summary>
        /// Global number: 722
        /// API name: COLUMN PIPE-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:number
        /// </summary>
        /// <returns></returns>
        public String VertPumpColumnPipeNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 723
        /// API name: COLUMN PIPE-SPACING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:spacing
        /// </summary>
        /// <param name="VertPumpColumnPipeSpacing"></param>
        public void VertPumpColumnPipeSpacing_Writer(String vertPumpColumnPipeSpacing)
        {
            if (String.IsNullOrEmpty(vertPumpColumnPipeSpacing))
                return;
        }

        /// <summary>
        /// Global number: 723
        /// API name: COLUMN PIPE-SPACING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:columnPipe/eqRot:spacing
        /// </summary>
        /// <returns></returns>
        public String VertPumpColumnPipeSpacing_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 836
        /// API name: SUMP-DISCHARGE COLUMN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeColumnMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpDischargeColMaterialName"></param>
        public void VertPumpDischargeColMaterialName_Writer(String vertPumpDischargeColMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpDischargeColMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 836
        /// API name: SUMP-DISCHARGE COLUMN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeColumnMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpDischargeColMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 837
        /// API name: SUMP-DISCHARGE HEAD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:isCast/eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:isFabricated
        /// </summary>
        /// <param name="VertPumpDischargeHeadIsCastFabricated"></param>
        public void VertPumpDischargeHeadIsCastFabricated_Writer(String vertPumpDischargeHeadIsCastFabricated)
        {
            if (String.IsNullOrEmpty(vertPumpDischargeHeadIsCastFabricated))
                return;
        }

        /// <summary>
        /// Global number: 837
        /// API name: SUMP-DISCHARGE HEAD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:isCast/eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:isFabricated
        /// </summary>
        /// <returns></returns>
        public String VertPumpDischargeHeadIsCastFabricated_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1747
        /// API name: Discharge Head Material
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpDischargeHeadMaterialName"></param>
        public void VertPumpDischargeHeadMaterialName_Writer(String vertPumpDischargeHeadMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpDischargeHeadMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 1747
        /// API name: Discharge Head Material
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpDischargeHeadMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 244
        /// API name: GRADE TO 1ST STG IMPL'R.-l5
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:gradeToFirstStageImpeller
        /// </summary>
        /// <param name="VertPumpGradeTo1stStageImpeller"></param>
        public void VertPumpGradeTo1stStageImpeller_Writer(String vertPumpGradeTo1stStageImpeller)
        {
            if (String.IsNullOrEmpty(vertPumpGradeTo1stStageImpeller))
                return;
        }

        /// <summary>
        /// Global number: 244
        /// API name: GRADE TO 1ST STG IMPL'R.-l5
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:gradeToFirstStageImpeller
        /// </summary>
        /// <returns></returns>
        public String VertPumpGradeTo1stStageImpeller_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 245
        /// API name: GRADE TO DISCH.-l3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:gradeToCenterLineOfDischarge
        /// </summary>
        /// <param name="VertPumpGradeToCentrelineDischargeL"></param>
        public void VertPumpGradeToCentrelineDischargeL_Writer(String vertPumpGradeToCentrelineDischargeL)
        {
            if (String.IsNullOrEmpty(vertPumpGradeToCentrelineDischargeL))
                return;
        }

        /// <summary>
        /// Global number: 245
        /// API name: GRADE TO DISCH.-l3
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:gradeToCenterLineOfDischarge
        /// </summary>
        /// <returns></returns>
        public String VertPumpGradeToCentrelineDischargeL_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 246
        /// API name: GRADE TO LOW LIQUID LVL-l4
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:gradeToLowLiquidLevel
        /// </summary>
        /// <param name="VertPumpGradeToLowerLiquidLevel"></param>
        public void VertPumpGradeToLowerLiquidLevel_Writer(String vertPumpGradeToLowerLiquidLevel)
        {
            if (String.IsNullOrEmpty(vertPumpGradeToLowerLiquidLevel))
                return;
        }

        /// <summary>
        /// Global number: 246
        /// API name: GRADE TO LOW LIQUID LVL-l4
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:gradeToLowLiquidLevel
        /// </summary>
        /// <returns></returns>
        public String VertPumpGradeToLowerLiquidLevel_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 247
        /// API name: GUIDE BUSHING-LUBE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:guideBushing/eqRot:guideBushingLubeType
        /// </summary>
        /// <param name="VertPumpGuideBushingLubeType"></param>
        public void VertPumpGuideBushingLubeType_Writer(String vertPumpGuideBushingLubeType)
        {
            if (String.IsNullOrEmpty(vertPumpGuideBushingLubeType))
                return;
        }

        /// <summary>
        /// Global number: 247
        /// API name: GUIDE BUSHING-LUBE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:guideBushing/eqRot:guideBushingLubeType
        /// </summary>
        /// <returns></returns>
        public String VertPumpGuideBushingLubeType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 248
        /// API name: GUIDE BUSHING-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:guideBushing/eqRot:number
        /// </summary>
        /// <param name="VertPumpGuideBushingNumber"></param>
        public void VertPumpGuideBushingNumber_Writer(String vertPumpGuideBushingNumber)
        {
            if (String.IsNullOrEmpty(vertPumpGuideBushingNumber))
                return;
        }

        /// <summary>
        /// Global number: 248
        /// API name: GUIDE BUSHING-NUMBER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:guideBushing/eqRot:number
        /// </summary>
        /// <returns></returns>
        public String VertPumpGuideBushingNumber_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 764
        /// API name: MOUNTING FLANGE REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:hasBaseplateMountingFlange
        /// </summary>
        /// <param name="VertPumpHasMountingFlange"></param>
        public void VertPumpHasMountingFlange_Writer(String vertPumpHasMountingFlange)
        {
            if (String.IsNullOrEmpty(vertPumpHasMountingFlange))
                return;
        }

        /// <summary>
        /// Global number: 764
        /// API name: MOUNTING FLANGE REQUIRED
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:hasBaseplateMountingFlange
        /// </summary>
        /// <returns></returns>
        public String VertPumpHasMountingFlange_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 802
        /// API name: PRESSURE RATING HEAD-HYDRO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:hydrostaticTestP
        /// </summary>
        /// <param name="VertPumpHeadHydroTestP"></param>
        public void VertPumpHeadHydroTestP_Writer(String vertPumpHeadHydroTestP)
        {
            if (String.IsNullOrEmpty(vertPumpHeadHydroTestP))
                return;
        }

        /// <summary>
        /// Global number: 802
        /// API name: PRESSURE RATING HEAD-HYDRO
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:hydrostaticTestP
        /// </summary>
        /// <returns></returns>
        public String VertPumpHeadHydroTestP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 803
        /// API name: PRESSURE RATING HEAD-MAWP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:mawp
        /// </summary>
        /// <param name="VertPumpHeadMAWP"></param>
        public void VertPumpHeadMAWP_Writer(String vertPumpHeadMAWP)
        {
            if (String.IsNullOrEmpty(vertPumpHeadMAWP))
                return;
        }

        /// <summary>
        /// Global number: 803
        /// API name: PRESSURE RATING HEAD-MAWP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:dischargeHead/eqRot:mawp
        /// </summary>
        /// <returns></returns>
        public String VertPumpHeadMAWP_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 266
        /// API name: IMPELLER COLLETS ACCEPTABLE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:isImpellerColletAcceptable
        /// </summary>
        /// <param name="VertPumpImpellerColletAcceptable"></param>
        public void VertPumpImpellerColletAcceptable_Writer(String vertPumpImpellerColletAcceptable)
        {
            if (String.IsNullOrEmpty(vertPumpImpellerColletAcceptable))
                return;
        }

        /// <summary>
        /// Global number: 266
        /// API name: IMPELLER COLLETS ACCEPTABLE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:isImpellerColletAcceptable
        /// </summary>
        /// <returns></returns>
        public String VertPumpImpellerColletAcceptable_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 455
        /// API name: PUMP LENGTH-l2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:shape/etl:shapeItem/etl:length
        /// </summary>
        /// <param name="VertPumpLength"></param>
        public void VertPumpLength_Writer(String vertPumpLength)
        {
            if (String.IsNullOrEmpty(vertPumpLength))
                return;
        }

        /// <summary>
        /// Global number: 455
        /// API name: PUMP LENGTH-l2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:shape/etl:shapeItem/etl:length
        /// </summary>
        /// <returns></returns>
        public String VertPumpLength_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 284
        /// API name: LEVEL CONTROL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:fluidLevelControl
        /// </summary>
        /// <param name="VertPumpLevelControl"></param>
        public void VertPumpLevelControl_Writer(String vertPumpLevelControl)
        {
            if (String.IsNullOrEmpty(vertPumpLevelControl))
                return;
        }

        /// <summary>
        /// Global number: 284
        /// API name: LEVEL CONTROL-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:fluidLevelControl
        /// </summary>
        /// <returns></returns>
        public String VertPumpLevelControl_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 839
        /// API name: SUMP-LINESHAFT BEARING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:bearingMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpLineShaftBearingMaterialName"></param>
        public void VertPumpLineShaftBearingMaterialName_Writer(String vertPumpLineShaftBearingMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftBearingMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 839
        /// API name: SUMP-LINESHAFT BEARING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:bearingMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftBearingMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 832
        /// API name: SUMP-BEARING RETAINER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:bearingRetainerMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpLineShaftBearingRetMaterialName"></param>
        public void VertPumpLineShaftBearingRetMaterialName_Writer(String vertPumpLineShaftBearingRetMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftBearingRetMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 832
        /// API name: SUMP-BEARING RETAINER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:bearingRetainerMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftBearingRetMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 230
        /// API name: GUIDE BUSHING-LINE SHAFT BEARING SPACING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:bearingSpacing
        /// </summary>
        /// <param name="VertPumpLineShaftBearingSpacing"></param>
        public void VertPumpLineShaftBearingSpacing_Writer(String vertPumpLineShaftBearingSpacing)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftBearingSpacing))
                return;
        }

        /// <summary>
        /// Global number: 230
        /// API name: GUIDE BUSHING-LINE SHAFT BEARING SPACING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:bearingSpacing
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftBearingSpacing_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 287
        /// API name: LINESHAFT CONNECTION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eq:couplingTypeFit
        /// </summary>
        /// <param name="VertPumpLineShaftCouplingTypeFit"></param>
        public void VertPumpLineShaftCouplingTypeFit_Writer(String vertPumpLineShaftCouplingTypeFit)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftCouplingTypeFit))
                return;
        }

        /// <summary>
        /// Global number: 287
        /// API name: LINESHAFT CONNECTION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eq:couplingTypeFit
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftCouplingTypeFit_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 289
        /// API name: LINESHAFT DIAMETER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:diameter
        /// </summary>
        /// <param name="VertPumpLineShaftDiam"></param>
        public void VertPumpLineShaftDiam_Writer(String vertPumpLineShaftDiam)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftDiam))
                return;
        }

        /// <summary>
        /// Global number: 289
        /// API name: LINESHAFT DIAMETER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:diameter
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftDiam_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 842
        /// API name: SUMP-SHAFT ENCLOSING TUBE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:enclosingTubeMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpLineShaftEncTubeMaterialName"></param>
        public void VertPumpLineShaftEncTubeMaterialName_Writer(String vertPumpLineShaftEncTubeMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftEncTubeMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 842
        /// API name: SUMP-SHAFT ENCLOSING TUBE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:enclosingTubeMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftEncTubeMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 840
        /// API name: SUMP-LINESHAFT HARDFACING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:hardFacingMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpLineShaftHFMaterialName"></param>
        public void VertPumpLineShaftHFMaterialName_Writer(String vertPumpLineShaftHFMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftHFMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 840
        /// API name: SUMP-LINESHAFT HARDFACING
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:hardFacingMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftHFMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 838
        /// API name: SUMP-LINESHAFT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpLineShaftMaterialName"></param>
        public void VertPumpLineShaftMaterialName_Writer(String vertPumpLineShaftMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 838
        /// API name: SUMP-LINESHAFT
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 841
        /// API name: SUMP-LINESHAFT SLEEVES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:sleeveMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpLineShaftSleeveMaterialName"></param>
        public void VertPumpLineShaftSleeveMaterialName_Writer(String vertPumpLineShaftSleeveMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftSleeveMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 841
        /// API name: SUMP-LINESHAFT SLEEVES
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:sleeveMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftSleeveMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 251
        /// API name: HARDENED SLEEVES UNDER BEARINGS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:hasHardSleeve
        /// </summary>
        /// <param name="VertPumpLineShaftSleeveUnderBearing"></param>
        public void VertPumpLineShaftSleeveUnderBearing_Writer(String vertPumpLineShaftSleeveUnderBearing)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftSleeveUnderBearing))
                return;
        }

        /// <summary>
        /// Global number: 251
        /// API name: HARDENED SLEEVES UNDER BEARINGS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:hasHardSleeve
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftSleeveUnderBearing_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 628
        /// API name: TUBE DIAMETER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:enclosingTubeDiameter
        /// </summary>
        /// <param name="VertPumpLineShaftTubeDiam"></param>
        public void VertPumpLineShaftTubeDiam_Writer(String vertPumpLineShaftTubeDiam)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftTubeDiam))
                return;
        }

        /// <summary>
        /// Global number: 628
        /// API name: TUBE DIAMETER-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:enclosingTubeDiameter
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftTubeDiam_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 286
        /// API name: LINESHAFT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:lineShaftType
        /// </summary>
        /// <param name="VertPumpLineShaftType"></param>
        public void VertPumpLineShaftType_Writer(String vertPumpLineShaftType)
        {
            if (String.IsNullOrEmpty(vertPumpLineShaftType))
                return;
        }

        /// <summary>
        /// Global number: 286
        /// API name: LINESHAFT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:lineShaft/eqRot:lineShaftType
        /// </summary>
        /// <returns></returns>
        public String VertPumpLineShaftType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 296
        /// API name: LOW LIQUID LEVEL-2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:lowLiquidLevel
        /// </summary>
        /// <param name="VertPumpLowLiquidLevel"></param>
        public void VertPumpLowLiquidLevel_Writer(String vertPumpLowLiquidLevel)
        {
            if (String.IsNullOrEmpty(vertPumpLowLiquidLevel))
                return;
        }

        /// <summary>
        /// Global number: 296
        /// API name: LOW LIQUID LEVEL-2
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:lowLiquidLevel
        /// </summary>
        /// <returns></returns>
        public String VertPumpLowLiquidLevel_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 610
        /// API name: AT MAX. FLOW-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Maximum"]
        /// </summary>
        /// <param name="VertPumpMaxFlowThrustDown"></param>
        public void VertPumpMaxFlowThrustDown_Writer(String vertPumpMaxFlowThrustDown)
        {
            if (String.IsNullOrEmpty(vertPumpMaxFlowThrustDown))
                return;
        }

        /// <summary>
        /// Global number: 610
        /// API name: AT MAX. FLOW-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Maximum"]
        /// </summary>
        /// <returns></returns>
        public String VertPumpMaxFlowThrustDown_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 611
        /// API name: AT MAX. FLOW-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Maximum"]
        /// </summary>
        /// <param name="VertPumpMaxFlowThrustUp"></param>
        public void VertPumpMaxFlowThrustUp_Writer(String vertPumpMaxFlowThrustUp)
        {
            if (String.IsNullOrEmpty(vertPumpMaxFlowThrustUp))
                return;
        }

        /// <summary>
        /// Global number: 611
        /// API name: AT MAX. FLOW-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Maximum"]
        /// </summary>
        /// <returns></returns>
        public String VertPumpMaxFlowThrustUp_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 609
        /// API name: MAX THRUST-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust
        /// </summary>
        /// <param name="VertPumpMaxThrustDown"></param>
        public void VertPumpMaxThrustDown_Writer(String vertPumpMaxThrustDown)
        {
            if (String.IsNullOrEmpty(vertPumpMaxThrustDown))
                return;
        }

        /// <summary>
        /// Global number: 609
        /// API name: MAX THRUST-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust
        /// </summary>
        /// <returns></returns>
        public String VertPumpMaxThrustDown_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 612
        /// API name: MAX THRUST-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust
        /// </summary>
        /// <param name="VertPumpMaxThrustUp"></param>
        public void VertPumpMaxThrustUp_Writer(String vertPumpMaxThrustUp)
        {
            if (String.IsNullOrEmpty(vertPumpMaxThrustUp))
                return;
        }

        /// <summary>
        /// Global number: 612
        /// API name: MAX THRUST-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Maximum"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust
        /// </summary>
        /// <returns></returns>
        public String VertPumpMaxThrustUp_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 613
        /// API name: AT MIN. FLOW-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Minimum"]
        /// </summary>
        /// <param name="VertPumpMinFlowThrustDown"></param>
        public void VertPumpMinFlowThrustDown_Writer(String vertPumpMinFlowThrustDown)
        {
            if (String.IsNullOrEmpty(vertPumpMinFlowThrustDown))
                return;
        }

        /// <summary>
        /// Global number: 613
        /// API name: AT MIN. FLOW-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Minimum"]
        /// </summary>
        /// <returns></returns>
        public String VertPumpMinFlowThrustDown_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 614
        /// API name: AT MIN. FLOW-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Minimum"]
        /// </summary>
        /// <param name="VertPumpMinFlowThrustUp"></param>
        public void VertPumpMinFlowThrustUp_Writer(String vertPumpMinFlowThrustUp)
        {
            if (String.IsNullOrEmpty(vertPumpMinFlowThrustUp))
                return;
        }

        /// <summary>
        /// Global number: 614
        /// API name: AT MIN. FLOW-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Minimum"]
        /// </summary>
        /// <returns></returns>
        public String VertPumpMinFlowThrustUp_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 615
        /// API name: AT RATED FLOW-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Rated"]
        /// </summary>
        /// <param name="VertPumpRatedFlowThrustDown"></param>
        public void VertPumpRatedFlowThrustDown_Writer(String vertPumpRatedFlowThrustDown)
        {
            if (String.IsNullOrEmpty(vertPumpRatedFlowThrustDown))
                return;
        }

        /// <summary>
        /// Global number: 615
        /// API name: AT RATED FLOW-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Toward equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Rated"]
        /// </summary>
        /// <returns></returns>
        public String VertPumpRatedFlowThrustDown_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 616
        /// API name: AT RATED FLOW-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Rated"]
        /// </summary>
        /// <param name="VertPumpRatedFlowThrustUp"></param>
        public void VertPumpRatedFlowThrustUp_Writer(String vertPumpRatedFlowThrustUp)
        {
            if (String.IsNullOrEmpty(vertPumpRatedFlowThrustUp))
                return;
        }

        /// <summary>
        /// Global number: 616
        /// API name: AT RATED FLOW-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[etl:propertyType="Unspecified"][eq:relativeThrustDirection="Away from equipment"]/eqRot:pumpToDriverThrust[@referenceProperty="Flowrate, Rated"]
        /// </summary>
        /// <returns></returns>
        public String VertPumpRatedFlowThrustUp_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 1920
        /// API name: VERTICAL PUMPS REMARKS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:remark
        /// </summary>
        /// <param name="VertPumpRemark"></param>
        public void VertPumpRemark_Writer(String vertPumpRemark)
        {
            if (String.IsNullOrEmpty(vertPumpRemark))
                return;
        }

        /// <summary>
        /// Global number: 1920
        /// API name: VERTICAL PUMPS REMARKS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:remark
        /// </summary>
        /// <returns></returns>
        public String VertPumpRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 548
        /// API name: SEPARATE MOUNTING PLATE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:hasSeparateMountingPlate
        /// </summary>
        /// <param name="VertPumpSeparateMntPlateRequired"></param>
        public void VertPumpSeparateMntPlateRequired_Writer(String vertPumpSeparateMntPlateRequired)
        {
            if (String.IsNullOrEmpty(vertPumpSeparateMntPlateRequired))
                return;
        }

        /// <summary>
        /// Global number: 548
        /// API name: SEPARATE MOUNTING PLATE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:hasSeparateMountingPlate
        /// </summary>
        /// <returns></returns>
        public String VertPumpSeparateMntPlateRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 805
        /// API name: PROVIDE SEPARATE SOLEPLATE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eqRot:hasSeparateSoleplate
        /// </summary>
        /// <param name="VertPumpSeparateSoleplateRequired"></param>
        public void VertPumpSeparateSoleplateRequired_Writer(String vertPumpSeparateSoleplateRequired)
        {
            if (String.IsNullOrEmpty(vertPumpSeparateSoleplateRequired))
                return;
        }

        /// <summary>
        /// Global number: 805
        /// API name: PROVIDE SEPARATE SOLEPLATE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eqRot:hasSeparateSoleplate
        /// </summary>
        /// <returns></returns>
        public String VertPumpSeparateSoleplateRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 540
        /// API name: SOLEPLATE-LENGTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eq:shape/eq:rectangularShipping/etl:length
        /// </summary>
        /// <param name="VertPumpSoleplateL"></param>
        public void VertPumpSoleplateL_Writer(String vertPumpSoleplateL)
        {
            if (String.IsNullOrEmpty(vertPumpSoleplateL))
                return;
        }

        /// <summary>
        /// Global number: 540
        /// API name: SOLEPLATE-LENGTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eq:shape/eq:rectangularShipping/etl:length
        /// </summary>
        /// <returns></returns>
        public String VertPumpSoleplateL_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 541
        /// API name: SOLEPLATE REQD-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:isSoleplate
        /// </summary>
        /// <param name="VertPumpSoleplateRequired"></param>
        public void VertPumpSoleplateRequired_Writer(String vertPumpSoleplateRequired)
        {
            if (String.IsNullOrEmpty(vertPumpSoleplateRequired))
                return;
        }

        /// <summary>
        /// Global number: 541
        /// API name: SOLEPLATE REQD-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate/eqRot:isSoleplate
        /// </summary>
        /// <returns></returns>
        public String VertPumpSoleplateRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 542
        /// API name: SOLEPLATE-THICKNESS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eq:shape/eq:rectangularShipping/etl:thickness
        /// </summary>
        /// <param name="VertPumpSoleplateThickness"></param>
        public void VertPumpSoleplateThickness_Writer(String vertPumpSoleplateThickness)
        {
            if (String.IsNullOrEmpty(vertPumpSoleplateThickness))
                return;
        }

        /// <summary>
        /// Global number: 542
        /// API name: SOLEPLATE-THICKNESS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eq:shape/eq:rectangularShipping/etl:thickness
        /// </summary>
        /// <returns></returns>
        public String VertPumpSoleplateThickness_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 543
        /// API name: SOLEPLATE-WIDTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eq:shape/eq:rectangularShipping/etl:width
        /// </summary>
        /// <param name="VertPumpSoleplateW"></param>
        public void VertPumpSoleplateW_Writer(String vertPumpSoleplateW)
        {
            if (String.IsNullOrEmpty(vertPumpSoleplateW))
                return;
        }

        /// <summary>
        /// Global number: 543
        /// API name: SOLEPLATE-WIDTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:baseplate[eqRot:isSoleplate="true"]/eq:shape/eq:rectangularShipping/etl:width
        /// </summary>
        /// <returns></returns>
        public String VertPumpSoleplateW_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 558
        /// API name: STATIC THRUST-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[eq:relativeThrustDirection="Toward equipment"]/eqRot:staticThrust
        /// </summary>
        /// <param name="VertPumpStaticThrustDown"></param>
        public void VertPumpStaticThrustDown_Writer(String vertPumpStaticThrustDown)
        {
            if (String.IsNullOrEmpty(vertPumpStaticThrustDown))
                return;
        }

        /// <summary>
        /// Global number: 558
        /// API name: STATIC THRUST-DOWN
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[eq:relativeThrustDirection="Toward equipment"]/eqRot:staticThrust
        /// </summary>
        /// <returns></returns>
        public String VertPumpStaticThrustDown_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 559
        /// API name: STATIC THRUST-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[eq:relativeThrustDirection="Away from equipment"]/eqRot:staticThrust
        /// </summary>
        /// <param name="VertPumpStaticThrustUp"></param>
        public void VertPumpStaticThrustUp_Writer(String vertPumpStaticThrustUp)
        {
            if (String.IsNullOrEmpty(vertPumpStaticThrustUp))
                return;
        }

        /// <summary>
        /// Global number: 559
        /// API name: STATIC THRUST-UP
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:operatingPerformance/eqRot:condition[eq:relativeThrustDirection="Away from equipment"]/eqRot:staticThrust
        /// </summary>
        /// <returns></returns>
        public String VertPumpStaticThrustUp_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 568
        /// API name: SUBMERGENCE REQ'D-l6
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:minSubmergenceDepth
        /// </summary>
        /// <param name="VertPumpSubmergenceRequired"></param>
        public void VertPumpSubmergenceRequired_Writer(String vertPumpSubmergenceRequired)
        {
            if (String.IsNullOrEmpty(vertPumpSubmergenceRequired))
                return;
        }

        /// <summary>
        /// Global number: 568
        /// API name: SUBMERGENCE REQ'D-l6
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:placementGeometry/eqRot:minSubmergenceDepth
        /// </summary>
        /// <returns></returns>
        public String VertPumpSubmergenceRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 574
        /// API name: SUCTION CAN-DIAMETER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/etl:diameter
        /// </summary>
        /// <param name="VertPumpSuctionCanDiam"></param>
        public void VertPumpSuctionCanDiam_Writer(String vertPumpSuctionCanDiam)
        {
            if (String.IsNullOrEmpty(vertPumpSuctionCanDiam))
                return;
        }

        /// <summary>
        /// Global number: 574
        /// API name: SUCTION CAN-DIAMETER
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/etl:diameter
        /// </summary>
        /// <returns></returns>
        public String VertPumpSuctionCanDiam_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 752
        /// API name: LINE SHAFT-DRAIN PIPED TO SURFACE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/eqRot:hasDrainPipedToSurface
        /// </summary>
        /// <param name="VertPumpSuctionCanHasDrainPipedToSurface"></param>
        public void VertPumpSuctionCanHasDrainPipedToSurface_Writer(String vertPumpSuctionCanHasDrainPipedToSurface)
        {
            if (String.IsNullOrEmpty(vertPumpSuctionCanHasDrainPipedToSurface))
                return;
        }

        /// <summary>
        /// Global number: 752
        /// API name: LINE SHAFT-DRAIN PIPED TO SURFACE
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/eqRot:hasDrainPipedToSurface
        /// </summary>
        /// <returns></returns>
        public String VertPumpSuctionCanHasDrainPipedToSurface_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 571
        /// API name: SUCTION CAN-LENGTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/etl:length
        /// </summary>
        /// <param name="VertPumpSuctionCanL"></param>
        public void VertPumpSuctionCanL_Writer(String vertPumpSuctionCanL)
        {
            if (String.IsNullOrEmpty(vertPumpSuctionCanL))
                return;
        }

        /// <summary>
        /// Global number: 571
        /// API name: SUCTION CAN-LENGTH
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/etl:length
        /// </summary>
        /// <returns></returns>
        public String VertPumpSuctionCanL_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 843
        /// API name: SUMP-SUCTION CAN BARREL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <param name="VertPumpSuctionCanMaterialName"></param>
        public void VertPumpSuctionCanMaterialName_Writer(String vertPumpSuctionCanMaterialName)
        {
            if (String.IsNullOrEmpty(vertPumpSuctionCanMaterialName))
                return;
        }

        /// <summary>
        /// Global number: 843
        /// API name: SUMP-SUCTION CAN BARREL
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/mtrl:constructionMaterialProperty/mtrl:material/objb:name
        /// </summary>
        /// <returns></returns>
        public String VertPumpSuctionCanMaterialName_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 572
        /// API name: SUCTION CAN-THICKNESS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/etl:thickness
        /// </summary>
        /// <param name="VertPumpSuctionCanThickness"></param>
        public void VertPumpSuctionCanThickness_Writer(String vertPumpSuctionCanThickness)
        {
            if (String.IsNullOrEmpty(vertPumpSuctionCanThickness))
                return;
        }

        /// <summary>
        /// Global number: 572
        /// API name: SUCTION CAN-THICKNESS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionCan/etl:thickness
        /// </summary>
        /// <returns></returns>
        public String VertPumpSuctionCanThickness_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 582
        /// API name: SUCTION STRAINER TYPE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionStrainerType
        /// </summary>
        /// <param name="VertPumpSuctionStrainerType"></param>
        public void VertPumpSuctionStrainerType_Writer(String vertPumpSuctionStrainerType)
        {
            if (String.IsNullOrEmpty(vertPumpSuctionStrainerType))
                return;
        }

        /// <summary>
        /// Global number: 582
        /// API name: SUCTION STRAINER TYPE-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:suctionStrainerType
        /// </summary>
        /// <returns></returns>
        public String VertPumpSuctionStrainerType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 583
        /// API name: SUMP DEPTH-l1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:sumpWell/etl:height
        /// </summary>
        /// <param name="VertPumpSumpDepth"></param>
        public void VertPumpSumpDepth_Writer(String vertPumpSumpDepth)
        {
            if (String.IsNullOrEmpty(vertPumpSumpDepth))
                return;
        }

        /// <summary>
        /// Global number: 583
        /// API name: SUMP DEPTH-l1
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:sumpWell/etl:height
        /// </summary>
        /// <returns></returns>
        public String VertPumpSumpDepth_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 584
        /// API name: SUMP DIAMETER-Ød
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:sumpWell/etl:diameter[@valueGeometryType="Inside"]
        /// </summary>
        /// <param name="VertPumpSumpDiam"></param>
        public void VertPumpSumpDiam_Writer(String vertPumpSumpDiam)
        {
            if (String.IsNullOrEmpty(vertPumpSumpDiam))
                return;
        }

        /// <summary>
        /// Global number: 584
        /// API name: SUMP DIAMETER-Ød
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:verticallySuspendedPump/eqRot:sumpWell/etl:diameter[@valueGeometryType="Inside"]
        /// </summary>
        /// <returns></returns>
        public String VertPumpSumpDiam_Reader()
        {
            return null;
        } 
        #endregion

        #region Page 7
        /// <summary>
        /// Global number: 486
        /// API name: THESE REFERENCES MUST BE LISTED BY THE MANUFACTURER-CASTING FACTORS USED IN DESIGN (TABLE 3)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Reference list - casting factors"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataRefCastingFactorRequired"></param>
        public void DocDataRefCastingFactorRequired_Writer(String docDataRefCastingFactorRequired)
        {
            if (String.IsNullOrEmpty(docDataRefCastingFactorRequired))
                return;
        }

        /// <summary>
        /// Global number: 486
        /// API name: THESE REFERENCES MUST BE LISTED BY THE MANUFACTURER-CASTING FACTORS USED IN DESIGN (TABLE 3)
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Reference list - casting factors"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataRefCastingFactorRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 309
        /// API name: SOURCE OF MATERIAL PROPERTIES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Reference list - material property source"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataRefMaterialSourceRequired"></param>
        public void DocDataRefMaterialSourceRequired_Writer(String docDataRefMaterialSourceRequired)
        {
            if (String.IsNullOrEmpty(docDataRefMaterialSourceRequired))
                return;
        }

        /// <summary>
        /// Global number: 309
        /// API name: SOURCE OF MATERIAL PROPERTIES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Reference list - material property source"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataRefMaterialSourceRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 9
        /// API name: AltWeldingStandards-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Reference list - welding codes and standards"]/dx:isRequired
        /// </summary>
        /// <param name="DocDataRefWeldingCodeRequired"></param>
        public void DocDataRefWeldingCodeRequired_Writer(String docDataRefWeldingCodeRequired)
        {
            if (String.IsNullOrEmpty(docDataRefWeldingCodeRequired))
                return;
        }

        /// <summary>
        /// Global number: 9
        /// API name: AltWeldingStandards-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:document[dx:dataOrReport="Reference list - welding codes and standards"]/dx:isRequired
        /// </summary>
        /// <returns></returns>
        public String DocDataRefWeldingCodeRequired_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 489
        /// API name: REMARKS PAGE 7
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:remark
        /// </summary>
        /// <param name="RequirementRemark"></param>
        public void RequirementRemark_Writer(String requirementRemark)
        {
            if (String.IsNullOrEmpty(requirementRemark))
                return;
        }

        /// <summary>
        /// Global number: 489
        /// API name: REMARKS PAGE 7
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:remark
        /// </summary>
        /// <returns></returns>
        public String RequirementRemark_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 290
        /// API name: LIQUID-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Liquid penetrant"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestLiqPenCastAcceptCriteriaDesc"></param>
        public void TestLiqPenCastAcceptCriteriaDesc_Writer(String testLiqPenCastAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testLiqPenCastAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 290
        /// API name: LIQUID-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Liquid penetrant"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestLiqPenCastAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 292
        /// API name: LIQUID PENETRANT INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Liquid penetrant"]/eq:description
        /// </summary>
        /// <param name="TestLiqPenDesc"></param>
        public void TestLiqPenDesc_Writer(String testLiqPenDesc)
        {
            if (String.IsNullOrEmpty(testLiqPenDesc))
                return;
        }

        /// <summary>
        /// Global number: 292
        /// API name: LIQUID PENETRANT INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Liquid penetrant"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestLiqPenDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 291
        /// API name: LIQUID-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Liquid penetrant"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestLiqPenFabAcceptCriteriaDesc"></param>
        public void TestLiqPenFabAcceptCriteriaDesc_Writer(String testLiqPenFabAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testLiqPenFabAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 291
        /// API name: LIQUID-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Liquid penetrant"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestLiqPenFabAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 298
        /// API name: MAGNETIC-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Magnetic particle"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestMagPartCastAcceptCriteriaDesc"></param>
        public void TestMagPartCastAcceptCriteriaDesc_Writer(String testMagPartCastAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testMagPartCastAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 298
        /// API name: MAGNETIC-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Magnetic particle"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestMagPartCastAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 301
        /// API name: MAGNETIC PARTICLE INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Magnetic particle"]/eq:description
        /// </summary>
        /// <param name="TestMagPartDesc"></param>
        public void TestMagPartDesc_Writer(String testMagPartDesc)
        {
            if (String.IsNullOrEmpty(testMagPartDesc))
                return;
        }

        /// <summary>
        /// Global number: 301
        /// API name: MAGNETIC PARTICLE INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Magnetic particle"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestMagPartDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 300
        /// API name: MAGNETIC-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Magnetic particle"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestMagPartFabAcceptCriteriaDesc"></param>
        public void TestMagPartFabAcceptCriteriaDesc_Writer(String testMagPartFabAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testMagPartFabAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 300
        /// API name: MAGNETIC-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Magnetic particle"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestMagPartFabAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 302
        /// API name: MAGNETIC PARTICLE OR LIQUID PENETRANT EXAMINATION OF PLATE EDGES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest/eq:plateEdgesExaminationType
        /// </summary>
        /// <param name="TestPlateEdgeExamType"></param>
        public void TestPlateEdgeExamType_Writer(String testPlateEdgeExamType)
        {
            if (String.IsNullOrEmpty(testPlateEdgeExamType))
                return;
        }

        /// <summary>
        /// Global number: 302
        /// API name: MAGNETIC PARTICLE OR LIQUID PENETRANT EXAMINATION OF PLATE EDGES-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest/eq:plateEdgesExaminationType
        /// </summary>
        /// <returns></returns>
        public String TestPlateEdgeExamType_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 473
        /// API name: RADIOGRAPHY-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Radiographic"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestRadiographicCastAcceptCriteriaDesc"></param>
        public void TestRadiographicCastAcceptCriteriaDesc_Writer(String testRadiographicCastAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testRadiographicCastAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 473
        /// API name: RADIOGRAPHY-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Radiographic"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestRadiographicCastAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 475
        /// API name: RADIOGRAPHY-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Radiographic"]/eq:description
        /// </summary>
        /// <param name="TestRadiographicDesc"></param>
        public void TestRadiographicDesc_Writer(String testRadiographicDesc)
        {
            if (String.IsNullOrEmpty(testRadiographicDesc))
                return;
        }

        /// <summary>
        /// Global number: 475
        /// API name: RADIOGRAPHY-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Radiographic"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestRadiographicDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 474
        /// API name: RADIOGRAPHY-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Radiographic"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestRadiographicFabAcceptCriteriaDesc"></param>
        public void TestRadiographicFabAcceptCriteriaDesc_Writer(String testRadiographicFabAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testRadiographicFabAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 474
        /// API name: RADIOGRAPHY-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Radiographic"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestRadiographicFabAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 632
        /// API name: ULTRASONIC-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Ultrasonic"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestUltrasonicCastAcceptCriteriaDesc"></param>
        public void TestUltrasonicCastAcceptCriteriaDesc_Writer(String testUltrasonicCastAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testUltrasonicCastAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 632
        /// API name: ULTRASONIC-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Ultrasonic"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestUltrasonicCastAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 634
        /// API name: ULTRASONIC INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Ultrasonic"]/eq:description
        /// </summary>
        /// <param name="TestUltrasonicDesc"></param>
        public void TestUltrasonicDesc_Writer(String testUltrasonicDesc)
        {
            if (String.IsNullOrEmpty(testUltrasonicDesc))
                return;
        }

        /// <summary>
        /// Global number: 634
        /// API name: ULTRASONIC INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Ultrasonic"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestUltrasonicDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 633
        /// API name: ULTRASONIC-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Ultrasonic"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestUltrasonicFabAcceptCriteriaDesc"></param>
        public void TestUltrasonicFabAcceptCriteriaDesc_Writer(String testUltrasonicFabAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testUltrasonicFabAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 633
        /// API name: ULTRASONIC-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Ultrasonic"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestUltrasonicFabAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 757
        /// API name: MATERIAL-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Visual"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestVisualCastAcceptCriteriaDesc"></param>
        public void TestVisualCastAcceptCriteriaDesc_Writer(String testVisualCastAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testVisualCastAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 757
        /// API name: MATERIAL-FOR CASTINGS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Visual"][eq:inspectionComponent/eq:inspectionComponentType="Casting"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestVisualCastAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 863
        /// API name: VISUAL INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Visual"]/eq:description
        /// </summary>
        /// <param name="TestVisualDesc"></param>
        public void TestVisualDesc_Writer(String testVisualDesc)
        {
            if (String.IsNullOrEmpty(testVisualDesc))
                return;
        }

        /// <summary>
        /// Global number: 863
        /// API name: VISUAL INSPECTION-METHOD
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Visual"]/eq:description
        /// </summary>
        /// <returns></returns>
        public String TestVisualDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 758
        /// API name: MATERIAL-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Visual"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <param name="TestVisualFabAcceptCriteriaDesc"></param>
        public void TestVisualFabAcceptCriteriaDesc_Writer(String testVisualFabAcceptCriteriaDesc)
        {
            if (String.IsNullOrEmpty(testVisualFabAcceptCriteriaDesc))
                return;
        }

        /// <summary>
        /// Global number: 758
        /// API name: MATERIAL-FOR FABRICATIONS
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pumpInspection/eqRot:pumpTest[eqRot:pumpInspectionTestType="Visual"][eq:inspectionComponent/eq:inspectionComponentType="Fabrication - unspecified"]/eq:acceptanceCriteriaDescription
        /// </summary>
        /// <returns></returns>
        public String TestVisualFabAcceptCriteriaDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 651
        /// API name: WELDER/OPERATOR QUALIFICATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Welder operator qualification"]/eq:weldingStandard
        /// </summary>
        /// <param name="WelderQualificationStd"></param>
        public void WelderQualificationStd_Writer(String welderQualificationStd)
        {
            if (String.IsNullOrEmpty(welderQualificationStd))
                return;
        }

        /// <summary>
        /// Global number: 651
        /// API name: WELDER/OPERATOR QUALIFICATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Welder operator qualification"]/eq:weldingStandard
        /// </summary>
        /// <returns></returns>
        public String WelderQualificationStd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 662
        /// API name: Welding Requirement
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding/eq:alternativeStandardDescription
        /// </summary>
        /// <param name="WeldingAlternativeStdDesc"></param>
        public void WeldingAlternativeStdDesc_Writer(String weldingAlternativeStdDesc)
        {
            if (String.IsNullOrEmpty(weldingAlternativeStdDesc))
                return;
        }

        /// <summary>
        /// Global number: 662
        /// API name: Welding Requirement
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding/eq:alternativeStandardDescription
        /// </summary>
        /// <returns></returns>
        public String WeldingAlternativeStdDesc_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 380
        /// API name: NON-PRESSURE RETAINING STRUCTURAL WELDING SUCH AS BASEPLATES OR SUPPORTS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Non-pressure retaining structure"]/eq:weldingStandard
        /// </summary>
        /// <param name="WeldingNonPRetainingStructuralStd"></param>
        public void WeldingNonPRetainingStructuralStd_Writer(String weldingNonPRetainingStructuralStd)
        {
            if (String.IsNullOrEmpty(weldingNonPRetainingStructuralStd))
                return;
        }

        /// <summary>
        /// Global number: 380
        /// API name: NON-PRESSURE RETAINING STRUCTURAL WELDING SUCH AS BASEPLATES OR SUPPORTS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Non-pressure retaining structure"]/eq:weldingStandard
        /// </summary>
        /// <returns></returns>
        public String WeldingNonPRetainingStructuralStd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 429
        /// API name: POSTWELD HEAT TREATMENT OF CASING FABRICATION WELDS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Post-welding heat treatment casing fabrication"]/eq:weldingStandard
        /// </summary>
        /// <param name="WeldingPostHeatTreatmentCasingFabStd"></param>
        public void WeldingPostHeatTreatmentCasingFabStd_Writer(String weldingPostHeatTreatmentCasingFabStd)
        {
            if (String.IsNullOrEmpty(weldingPostHeatTreatmentCasingFabStd))
                return;
        }

        /// <summary>
        /// Global number: 429
        /// API name: POSTWELD HEAT TREATMENT OF CASING FABRICATION WELDS-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Post-welding heat treatment casing fabrication"]/eq:weldingStandard
        /// </summary>
        /// <returns></returns>
        public String WeldingPostHeatTreatmentCasingFabStd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 430
        /// API name: POSTWELD HEAT TREATMENT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Post-welding heat treatment"]/eq:weldingStandard
        /// </summary>
        /// <param name="WeldingPostHeatTreatmentStd"></param>
        public void WeldingPostHeatTreatmentStd_Writer(String weldingPostHeatTreatmentStd)
        {
            if (String.IsNullOrEmpty(weldingPostHeatTreatmentStd))
                return;
        }

        /// <summary>
        /// Global number: 430
        /// API name: POSTWELD HEAT TREATMENT-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Post-welding heat treatment"]/eq:weldingStandard
        /// </summary>
        /// <returns></returns>
        public String WeldingPostHeatTreatmentStd_Reader()
        {
            return null;
        }

        /// <summary>
        /// Global number: 652
        /// API name: WELDING PROCEDURE QUALIFICATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Welding procedure"]/eq:weldingStandard
        /// </summary>
        /// <param name="WeldingProcedureQualificationStd"></param>
        public void WeldingProcedureQualificationStd_Writer(String weldingProcedureQualificationStd)
        {
            if (String.IsNullOrEmpty(weldingProcedureQualificationStd))
                return;
        }

        /// <summary>
        /// Global number: 652
        /// API name: WELDING PROCEDURE QUALIFICATION-
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:requirement/eq:welding[eq:weldingQualityControl="Welding procedure"]/eq:weldingStandard
        /// </summary>
        /// <returns></returns>
        public String WeldingProcedureQualificationStd_Reader()
        {
            return null;
        } 
        #endregion

    }
}
