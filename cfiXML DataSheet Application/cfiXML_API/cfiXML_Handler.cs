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

    //TODO: atualizar sumário
    /// <summary>
    /// - Esta classe vai conter todos os metodos para escrever no xml padrão cfi. Criando um xml utilizando os metodos desta classe, você garante que não vai existir nós
    /// com o mesmo nome. Caso no xml corrente já exista um caminho para ser aproveitado, este caminho será aproveitado para a inserção de um valor.
    /// 
    /// - Todos os metodos desta classe assumem que nunca irao atualizar um xml, eles sempre vao ser utilizados para criar um novo xml.
    /// 
    /// - Todos os metodos só acessam o ultimo só onde ele vai inserir o valor.
    ///     
    /// - Todos os métodos que escrevem um valor que seria um enumeration no cfiXML se comportam da seguinte maneira*:
    ///     Se o string recebido é igual a algum string do enumeration, ele cria o enumeration e o insere no xml.
    ///     Se o string for diferente, ele insere no enum (Custom ou Other ou Unspecified) e coloca como atributo do nó (atributo = OtherValue) a string recebida.
    ///     
    /// 
    /// 
    /// 
    /// 
    /// (*) De acordo com a espeficicação do cfiXML
    /// </summary>
    public partial class cfiXML_Handler
    {

        private int _transactionOrder = 1;

        private cfiXML_Enums _cfiXML_Enums = new cfiXML_Enums();

        private Utils _utils = new Utils();

        private eqRotDoc.eqRotDoc _xml = null;

        /// <summary>
        /// Contém o caminho para o xml.
        /// </summary>
        private String _xmlPath = null;


        // Inicialização do xml
        /// <summary>
        /// Método utilizado para criar um novo xml no padrão cfiXML 4.0.
        /// </summary>
        /// <param name="xmlPath"></param>
        public void CreateXML_to_Write(String xmlPath)
        {
            _xmlPath = xmlPath;
            _xml = eqRotDoc.eqRotDoc.CreateDocument();
        }

        /// <summary>
        /// Método utilizado para ler um xml no padrão cfiXML 4.0.
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public Boolean SelectXML_to_Read(String xmlPath)
        {
            _xmlPath = xmlPath;

            try
            {
                _xml = eqRotDoc.eqRotDoc.LoadFromFile(_xmlPath);
            }
            catch (Exception e)
            {
                _xml = null;
                // O xml está vazio, sem um nó raiz ou ele não existe.
            }

            if (_xml == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Método utilizado para salvar as mudanças feitas para um xml. Ao término do uso dos métodos de escrita no XML deve-se utilizar este método para persistir as mudanças no XML.
        /// </summary>
        public void SaveToFile()
        {
            if (_xmlPath != null && _xml != null)
                _xml.SaveToFile(_xmlPath, true);
            else
                throw new Exception(Messages._saveToFileErrorMessage);
        }


        // Metodos Privados
        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private CentrifugalPumpDataSheet centrifugalPumpDataSheet2()
        {
            CentrifugalPumpDataSheet cPumpDataSheet = null;
            if (!_xml.centrifugalPumpDataSheet2.Exists)
            {
                cPumpDataSheet = _xml.centrifugalPumpDataSheet2.Append();

                // Trecho de código só para incluir o local do schema no novo xml criado.
                // Ele tem que ser criado aqui porque é preciso ter ó nó raiz para inclusão deste namespace.
                SaveToFile();
                _xml.SetSchemaLocation(@"..\schema\document\eqRotDoc.xsd");

                return cPumpDataSheet;
            }

            return _xml.centrifugalPumpDataSheet2.First;
        }


        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.site.SiteFacility siteFacility()
        {
            CentrifugalPumpDataSheet cenPump = centrifugalPumpDataSheet2();

            if (!cenPump.siteFacility.Exists)
            {
                return cenPump.siteFacility.Append();
            }

            return cenPump.siteFacility.First;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.proj.Project project()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (!dSheetHeader.project.Exists)
            {
                return dSheetHeader.project.Append();
            }

            return dSheetHeader.project.First;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.site.FacilitySystem facilitySystem()
        {
            eqRotDoc.site.SiteFacility sFacility = siteFacility();

            if (!sFacility.facilitySystem2.Exists)
            {
                return sFacility.facilitySystem2.Append();
            }

            return sFacility.facilitySystem2.First;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/site:equipmentSet
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.site.EquipmentSet equipmentSet()
        {
            eqRotDoc.site.FacilitySystem fSystem = facilitySystem();

            if (!fSystem.equipmentSet2.Exists)
            {
                return fSystem.equipmentSet2.Append();
            }

            return fSystem.equipmentSet2.First;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/site:equipmentSet/site:equipmentConfiguration
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.site.EquipmentConfiguration equipmentConfiguration()
        {
            eqRotDoc.site.EquipmentSet equiSet = equipmentSet();

            if (!equiSet.equipmentConfiguration2.Exists)
            {
                return equiSet.equipmentConfiguration2.Append();
            }

            return equiSet.equipmentConfiguration2.First;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private DataSheetHeader dataSheetHeader2()
        {
            CentrifugalPumpDataSheet cenPump = centrifugalPumpDataSheet2();

            if (!cenPump.dataSheetHeader2.Exists)
            {
                return cenPump.dataSheetHeader2.Append();
            }

            return cenPump.dataSheetHeader2.First;
        }

        // /eqRotDoc:centrifugalPumpDataSheet/obj:transaction[obj:revision=/eqRotDoc:centrifugalPumpDataSheet/@revision][obj:transactionType="Modified"]/obj:dateTime
        /// <summary>
        /// Este metodo só pode ser utilizado depois que o atributo revisão do centrifugalPump já estiver escrito no xml.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.obj.Transaction getTransactionNode(String revision, String transactionType)
        { // cria um transaction com o type modified se ele nao existir, caso exista ele só retorna

            CentrifugalPumpDataSheet cenPump = centrifugalPumpDataSheet2();

            eqRotDoc.obj.ETransactionTypeType.EnumValues transType = cfiXML_Enums.getTransactionType(transactionType);

            int rev = Convert.ToInt32(revision);
            int currentRev = Convert.ToInt32(RevisionID_Reader());

            if (rev > currentRev)
            {
                new Exception(Messages._transactionWithTypeError1);
                return null;
            }

            if (transType.Equals(eqRotDoc.obj.ETransactionTypeType.EnumValues.eNil))
            {
                new Exception(Messages._transactionWithTypeError2);
                return null;
            }

            if (cenPump.transaction2.Exists)
            { // Já existe um transaction
                for (int j = 0; j < cenPump.transaction2.Count; j++)
                {
                    if (cenPump.transaction2[j].transactionType.Exists)
                    {
                        // Só existe um transaction type por transaction
                        if (cenPump.transaction2[j].transactionType.First.EnumerationValue.Equals(transType))
                        {
                            // verifico se o revision dela é o mesmo que o parametro recebido revision
                            if (cenPump.transaction2[j].revision.Exists)
                            {
                                if (revision.Equals(cenPump.transaction2[j].revision.First.Value))
                                { // Só existe um elemento revision dentro de transaction
                                    return cenPump.transaction2[j];
                                }
                            }
                        }

                    }
                }
            }

            // nao existe transaction com o transactionType desejado e o revision desejado
            eqRotDoc.obj.Transaction transaction = cenPump.transaction2.Append();

            // Inserindo um order para cda transaction criada
            transaction.order.Append().Value = _transactionOrder;
            _transactionOrder++;

            transaction.transactionType.Append().EnumerationValue = transType;
            transaction.revision.Append().Value = revision;

            return transaction;

        }

        /// <summary>
        /// Retorna a revisão de um nó transaction qualquer do xml. Esta função é útil quando o xml só possui uma revisão e o nó raiz não contém o atributo revision.
        /// </summary>
        /// <returns></returns>
        private String getRevisionOfAnyTransactionNode()
        { // cria um transaction com o type modified se ele nao existir, caso exista ele só retorna

            CentrifugalPumpDataSheet cenPump = centrifugalPumpDataSheet2();

            if (cenPump.transaction2.Exists)
            { // Já existe um transaction

                return cenPump.transaction2.First.revision.First.Value;
            }
            else
                return null;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Driver"]
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private AssociatedDataSheet AssociatedDataSheet_documentEquipmentType_Driver()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (dSheetHeader.associatedDataSheet2.Exists)
            { // Já existe um associatedDataSheet
                for (int j = 0; j < dSheetHeader.associatedDataSheet2.Count; j++)
                {
                    if (dSheetHeader.associatedDataSheet2[j].documentEquipmentType.Exists)
                    { // Procurar se existe um associatedDataSheet com o documentEquipmentType = Driver
                        for (int i = 0; i < dSheetHeader.associatedDataSheet2[j].documentEquipmentType.Count; i++)
                        {
                            if (dSheetHeader.associatedDataSheet2[j].documentEquipmentType[i].EnumerationValue.Equals(EDocumentEquipmentTypeType.EnumValues.eDriver))
                            { // Existe
                                return dSheetHeader.associatedDataSheet2[j];
                            }
                        }


                    }
                }
            }

            // nao existe
            AssociatedDataSheet alternativeDocumentID = dSheetHeader.associatedDataSheet2.Append();
            alternativeDocumentID.documentEquipmentType.Append().EnumerationValue = EDocumentEquipmentTypeType.EnumValues.eDriver;

            return alternativeDocumentID;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Gears"]
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private AssociatedDataSheet AssociatedDataSheet_documentEquipmentType_Gear()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (dSheetHeader.associatedDataSheet2.Exists)
            { // Já existe um associatedDataSheet
                for (int j = 0; j < dSheetHeader.associatedDataSheet2.Count; j++)
                {
                    if (dSheetHeader.associatedDataSheet2[j].documentEquipmentType.Exists)
                    { // Procurar se existe um associatedDataSheet com o documentEquipmentType = Gears
                        for (int i = 0; i < dSheetHeader.associatedDataSheet2[j].documentEquipmentType.Count; i++)
                        {
                            if (dSheetHeader.associatedDataSheet2[j].documentEquipmentType[i].EnumerationValue.Equals(EDocumentEquipmentTypeType.EnumValues.eGears))
                            { // Existe
                                return dSheetHeader.associatedDataSheet2[j];
                            }
                        }


                    }
                }
            }

            // nao existe
            AssociatedDataSheet alternativeDocumentID = dSheetHeader.associatedDataSheet2.Append();
            alternativeDocumentID.documentEquipmentType.Append().EnumerationValue = EDocumentEquipmentTypeType.EnumValues.eGears;

            return alternativeDocumentID;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:associatedDataSheet[dx:documentEquipmentType="Turbine"]/dx:id
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private AssociatedDataSheet AssociatedDataSheet_documentEquipmentType_Turbine()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (dSheetHeader.associatedDataSheet2.Exists)
            { // Já existe um associatedDataSheet
                for (int j = 0; j < dSheetHeader.associatedDataSheet2.Count; j++)
                {
                    if (dSheetHeader.associatedDataSheet2[j].documentEquipmentType.Exists)
                    { // Procurar se existe um associatedDataSheet com o documentEquipmentType = Gears
                        for (int i = 0; i < dSheetHeader.associatedDataSheet2[j].documentEquipmentType.Count; i++)
                        {
                            if (dSheetHeader.associatedDataSheet2[j].documentEquipmentType[i].EnumerationValue.Equals(EDocumentEquipmentTypeType.EnumValues.eTurbine))
                            { // Existe
                                return dSheetHeader.associatedDataSheet2[j];
                            }
                        }


                    }
                }
            }

            // nao existe
            AssociatedDataSheet alternativeDocumentID = dSheetHeader.associatedDataSheet2.Append();
            alternativeDocumentID.documentEquipmentType.Append().EnumerationValue = EDocumentEquipmentTypeType.EnumValues.eTurbine;

            return alternativeDocumentID;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:documentID
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private documentIDType documentID()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (!dSheetHeader.documentID.Exists)
            {
                return dSheetHeader.documentID.Append();
            }

            return dSheetHeader.documentID.First;
        }





        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump
        /// </summary>
        private eqRotDoc.eqRot.CentrifugalPump centrifugalPump()
        {
            CentrifugalPumpDataSheet cenPump = centrifugalPumpDataSheet2();

            if (!cenPump.centrifugalPump.Exists)
            {
                return cenPump.centrifugalPump.Append();
            }

            return cenPump.centrifugalPump.First;
        }

        // /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]
        // /uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:vaporP


        private void get_referencePropertyNode()
        {

        }


        /// <summary>
        /// Em construção... VITOR
        /// O codigo gerado não tem um nó property desta forma: "mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]"
        /// Que tenha um context que possua nós mtrl:referenceProperty
        /// </summary>
        /// <param name="referenceProperty"></param>
        private void mtrl_property(String referenceProperty)
        {
            eqRotDoc.mtrl.MaterialProperty mProperty = materialProperty(eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

            if (mProperty.property2.Exists)
            { // Já existe um property2
                for (int j = 0; j < mProperty.property2.Count; j++)
                {
                    // Testar se ele tem um nó context
                    if (!mProperty.property2[j].context.Exists)
                    {// Já existe um nó context

                        // Verificar se este nó context tem um referenceProperty = ao desejado.
                        // Se sim, retorna ele.
                        // Se nao, cria ele e retorna ele.

                        _xml.context.Append().referenceProperty.Append().Value = "Teste";




                        //eqRotDoc.eqRotDoc.MemberElement_context ctx = (eqRotDoc.eqRotDoc.MemberElement_context) mProperty.property2[j].context.First;

                        eqRotDoc.mtrl.propertyType2.MemberElement_context ctx2 = mProperty.property2[j].context;

                        //contextType ctx = (contextType) ctx2;// mProperty.property2[j].context.First;


                        eqRotDoc.mtrl.contextType cType = mProperty.property2[j].context.First;



                        //if(  ) // Cada property só tem um nó context.
                        //{

                        //}
                    }
                }
                // Já existe um nó property mas nao existe um nó contex com o referenceProperty desejado.

            }
            // Nao tem um nó property, cria ele do zero.

        }



        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.mtrl.MaterialProperty materialProperty(eqRotDoc.etl.ENormalFlowDirectionType.EnumValues flowDirectionType)
        {
            eqRotDoc.uo.MaterialStream mStream = materialStream_OperatingPerformance(flowDirectionType);

            if (!mStream.materialProperty.Exists)
            {
                return mStream.materialProperty.Append();
            }

            return mStream.materialProperty.First;
        }


        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:t
        /// </summary>
        /// <param name="contextPropertyType"></param>
        /// <param name="context_PropertyType"></param>
        /// <returns></returns>
        private eqRotDoc.mtrl.propertyType2 mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues context_PropertyType, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues flowDirectionType)
        {
            eqRotDoc.mtrl.MaterialProperty mProperty = materialProperty(flowDirectionType);

            if (mProperty.property2.Exists)
            { // Já existe um property2
                for (int j = 0; j < mProperty.property2.Count; j++)
                {
                    // Testar se ele tem um nó context
                    if (mProperty.property2[j].context.Exists)
                    {// Já existe um nó context (o nó context só existe um)

                        if (mProperty.property2[j].context.First.propertyType3.Exists)
                        { // Já existe a propriedade propertyType (Também só pode existir uma dentro de context)
                            if (mProperty.property2[j].context.First.propertyType3.First.EnumerationValue.Equals(context_PropertyType))
                            { // A propriedade propertyType de context é igual a desejada no argumento do metodo. (Encontrei o nó mtrl:property que eu quero inserir o nó mtrl:t
                                return mProperty.property2[j];
                            }
                        }
                    }

                }
            }

            // Passei por todos o mtrl:property e não encontrei um que tenha um context com o property type igual ao desejado pelo argumento, então vou criar um novo nó property com esse context.

            eqRotDoc.mtrl.propertyType2 returnNode = mProperty.property2.Append();
            returnNode.context.Append().propertyType3.Append().EnumerationValue = context_PropertyType;

            return returnNode;
        }


        // /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/uo:materialFlow[etl:flowPropertyType="arg1"][etl:valueSourceType="arg2"]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flowPropertyType">É obrigatório</param>
        /// <param name="valueSourceType">Se for null ele nao poe esse nó</param>
        /// <returns></returns>
        private eqRotDoc.uo.MaterialFlow materialFlow_OperatingPerformance(eqRotDoc.etl.EPropertyTypeType.EnumValues flowPropertyType, eqRotDoc.etl.EValueSourceTypeType.EnumValues valueSourceType, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues flowDirectionType)
        {
            eqRotDoc.uo.MaterialStream mStream = materialStream_OperatingPerformance(flowDirectionType);

            if (mStream.materialFlow2.Exists)
            { // ja tem um nó material flow
                for (int i = 0; i < mStream.materialFlow2.Count; i++)
                { // Cada materialFlow2 só possui um flowPropertyType
                    if (mStream.materialFlow2[i].flowPropertyType.Exists)
                        if (mStream.materialFlow2[i].flowPropertyType.First.EnumerationValue.Equals(flowPropertyType))
                        { // Encontrei o materialFlow que possui um flow property type igual a maximum.

                            if (!valueSourceType.Equals(eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil))
                            { // esse nó possui uma restricao valueSourceType.
                                if (mStream.materialFlow2[i].valueSourceType.First.EnumerationValue.Equals(valueSourceType))
                                {
                                    return mStream.materialFlow2[i];
                                }
                            }
                            else
                            { // nó não possui uma restrição valueSourceType.
                                return mStream.materialFlow2[i];
                            }
                        }
                }
            }

            eqRotDoc.uo.MaterialFlow returnNode = mStream.materialFlow2.Append();
            returnNode.flowPropertyType.Append().EnumerationValue = flowPropertyType;

            if (!valueSourceType.Equals(eqRotDoc.etl.EValueSourceTypeType.EnumValues.eNil))
            {
                returnNode.valueSourceType.Append().EnumerationValue = valueSourceType;
            }

            return returnNode;
        }


        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.uo.MaterialStream materialStream_OperatingPerformance(eqRotDoc.etl.ENormalFlowDirectionType.EnumValues flowDirectionType)
        {
            eqRotDoc.eqRot.streamConnectionType3 sConnection = streamConnection(eqRotDoc.ext.EUsageContext.EnumValues.eOperating_performance, flowDirectionType);

            if (!sConnection.materialStream2.Exists)
            {
                return sConnection.materialStream2.Append();
            }

            return sConnection.materialStream2.First;
        }


        /// <summary>
        /// VITOR: Parou aqui, Testar esta classe! Ela vai ser usada para muitos atributos da API
        /// 
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]
        /// OBS: para qualquer usageContext e qualquer normalFlowDirection.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="usageContext"></param>
        /// <param name="normalFlowDirection"></param>
        /// <returns></returns>
        private eqRotDoc.eqRot.streamConnectionType3 streamConnection(eqRotDoc.ext.EUsageContext.EnumValues usageContext, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues normalFlowDirection)
        {
            eqRotDoc.eqRot.CentrifugalPump eqRotCenPump = centrifugalPump();

            if (eqRotCenPump.streamConnection.Exists)
            { // Já existe um streamConnection
                for (int j = 0; j < eqRotCenPump.streamConnection.Count; j++)
                {
                    // Testar se ele tem o atributo usageContext desejado
                    if (!eqRotCenPump.streamConnection[j].usageContext.EnumerationValue.Equals(usageContext))
                        continue; // o streamConnection precisa ser do tipo desejado.

                    if (eqRotCenPump.streamConnection[j].normalFlowDirection.Exists)
                    { // Procurar se existe um streamConnection com o normalFlowDirection = normalFlowDirection(do argumento)
                        // Sempre tem que ter só um normalFlowDirection para cada streamConnection.

                        if (eqRotCenPump.streamConnection[j].normalFlowDirection.First.EnumerationValue.Equals(normalFlowDirection))
                        { // Existe
                            return eqRotCenPump.streamConnection[j];
                        }


                    }
                }
            }

            // nao existe
            eqRotDoc.eqRot.streamConnectionType3 sConnection = eqRotCenPump.streamConnection.Append();
            sConnection.usageContext.EnumerationValue = usageContext;
            sConnection.normalFlowDirection.Append().EnumerationValue = normalFlowDirection;

            return sConnection;
        }


        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/dx:orderLine
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private OrderLine orderLine()
        {
            eqRotDoc.eqRot.CentrifugalPump eqRotCenPump = centrifugalPump();

            if (!eqRotCenPump.orderLine.Exists)
            {
                return eqRotCenPump.orderLine.Append();
            }

            return eqRotCenPump.orderLine.First;
        }


        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.eqRot.applicableStandardType4 applicableStandard()
        {
            eqRotDoc.eqRot.CentrifugalPump eqRotCenPump = centrifugalPump();

            if (!eqRotCenPump.applicableStandard.Exists)
            {
                return eqRotCenPump.applicableStandard.Append();
            }

            return eqRotCenPump.applicableStandard.First;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.eq.idType centrifugalPump_ID()
        {
            eqRotDoc.eqRot.CentrifugalPump eqRotCenPump = centrifugalPump();

            if (!eqRotCenPump.id.Exists)
            {
                return eqRotCenPump.id.Append();
            }

            return eqRotCenPump.id.First;
        }


        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/ctx:manufacturerCompany
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private Organization manufacturerCompany()
        {
            eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

            if (!cPumpID.manufacturerCompany.Exists)
            {
                return cPumpID.manufacturerCompany.Append();
            }

            return cPumpID.manufacturerCompany.First;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/etl:serviceCategory
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private eqRotDoc.etl.ServiceCategory serviceCategory()
        {
            eqRotDoc.eqRot.CentrifugalPump eqRotCenPump = centrifugalPump();

            if (!eqRotCenPump.serviceCategory.Exists)
            {
                return eqRotCenPump.serviceCategory.Append();
            }

            return eqRotCenPump.serviceCategory.First;
        }


        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:alternativeDocumentID[dx:documentType="Requisition"]
        /// </summary>
        /// <param name="xml"></param>
        private AlternativeDocumentID AlternativeDocumentID_Requisition()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (dSheetHeader.alternativeDocumentID2.Exists)
            { // Já existe um alternativeDocumentID
                for (int j = 0; j < dSheetHeader.alternativeDocumentID2.Count; j++)
                {
                    if (dSheetHeader.alternativeDocumentID2[j].documentType.Exists)
                    { // Procurar se existe um alternativeDocumentID com o documentType = Requisition
                        for (int i = 0; i < dSheetHeader.alternativeDocumentID2[j].documentType.Count; i++)
                        {
                            if (dSheetHeader.alternativeDocumentID2[j].documentType[i].EnumerationValue.Equals(EDocumentTypeType.EnumValues.eRequisition))
                            { // Existe
                                return dSheetHeader.alternativeDocumentID2[j];
                            }
                        }


                    }
                }
            }

            // nao existe
            AlternativeDocumentID alternativeDocumentID = dSheetHeader.alternativeDocumentID2.Append();
            alternativeDocumentID.documentType.Append().EnumerationValue = EDocumentTypeType.EnumValues.eRequisition;

            return alternativeDocumentID;
        }

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:alternativeDocumentID[dx:documentType="Purchase Order (P/O)"]/dx:id
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private AlternativeDocumentID AlternativeDocumentID_PurchaseOrder()
        {
            DataSheetHeader dSheetHeader = dataSheetHeader2();

            if (dSheetHeader.alternativeDocumentID2.Exists)
            { // Já existe um alternativeDocumentID
                for (int j = 0; j < dSheetHeader.alternativeDocumentID2.Count; j++)
                {
                    if (dSheetHeader.alternativeDocumentID2[j].documentType.Exists)
                    { // Procurar se existe um alternativeDocumentID com o documentType = Purchase Order (P/O)
                        for (int i = 0; i < dSheetHeader.alternativeDocumentID2[j].documentType.Count; i++)
                        {
                            if (dSheetHeader.alternativeDocumentID2[j].documentType[i].EnumerationValue.Equals(EDocumentTypeType.EnumValues.ePurchase_Order__P_O_))
                            { // Existe
                                return dSheetHeader.alternativeDocumentID2[j];
                            }
                        }


                    }
                }
            }

            // nao existe
            AlternativeDocumentID alternativeDocumentID = dSheetHeader.alternativeDocumentID2.Append();
            alternativeDocumentID.documentType.Append().EnumerationValue = EDocumentTypeType.EnumValues.ePurchase_Order__P_O_;

            return alternativeDocumentID;
        }

        /// <summary>
        /// Cria um nó organizationContext com um organization role igual a Owner.
        /// Caso já exista um ele não cria, só retorna o organizationContext que ele está.
        /// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/proj:project/ctx:organizationContext[ctx:organizationRole="Owner"]
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private OrganizationContext OrganizationContext_Owner()
        {
            eqRotDoc.proj.Project proj = project();

            if (proj.organizationContext.Exists)
            { // Já existe um organizationContext
                for (int j = 0; j < proj.organizationContext.Count; j++)
                {
                    if (proj.organizationContext[j].organizationRole.Exists)
                    { // Procurar se existe um organizationContext com o organizationRole = owner
                        for (int i = 0; i < proj.organizationContext[j].organizationRole.Count; i++)
                        {
                            if (proj.organizationContext[j].organizationRole[i].EnumerationValue.Equals(organizationRoleType.EnumValues.eOwner))
                            { // Existe
                                return proj.organizationContext[j];
                            }
                        }


                    }
                }
            }

            // nao existe
            OrganizationContext context = proj.organizationContext.Append();
            context.organizationRole.Append().EnumerationValue = organizationRoleType.EnumValues.eOwner;

            return context;
        }

        /******************************************************** Métodos Públicos ********************************************************/

        ///// <summary>
        ///// Global number 15
        ///// API Name: applicable overlay standards
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:remark
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpStandardRemark"></param>
        //public void PumpStandardRemark_Writer(String pumpStandardRemark)
        //{
        //    if (pumpStandardRemark == null || pumpStandardRemark.Equals(String.Empty))
        //        return;

        //    eqRotDoc.eqRot.applicableStandardType4 appStandard = applicableStandard();

        //    if (!appStandard.remark.Exists)
        //    {
        //        appStandard.remark.Append();
        //    }

        //    appStandard.remark.First.Value = pumpStandardRemark;
        //}

        //public String PumpStandardRemark_Reader()
        //{
        //    eqRotDoc.eqRot.applicableStandardType4 appStandard = applicableStandard();

        //    if (!appStandard.remark.Exists)
        //    {
        //        return String.Empty;
        //    }

        //    return appStandard.remark.First.Value;
        //}

        /// <summary>Joao Paulo
        /// Caso especial. Revisões "/eqRotDoc:centrifugalPumpDataSheet/obj:transaction/obj:revision"
        /// </summary>
        /// <returns>Retorna lista de todas as revisões presentes no documento xml.</returns>
        public List<String> RevisionID_All_Reader()
        {
            List<string> revisionlist = new List<string>();
            List<int> orderlist = new List<int>();

            string[] revset = new string[centrifugalPumpDataSheet2().transaction2.Count];

            //XmlNodeList nodes = xmldoc.SelectNodes(, nsm);
            for (int i = 0; i < centrifugalPumpDataSheet2().transaction2.Count; i++)
            {
                revset[i] = centrifugalPumpDataSheet2().transaction2[i].revision.First.Value;
            }

            string last_rev = String.Empty;

            for (int i = 0; i < centrifugalPumpDataSheet2().transaction2.Count; i++)
            {
                if (!revset[i].Equals(last_rev))
                {
                    revisionlist.Add(revset[i]);
                    last_rev = revset[i];
                }
            }
            return revisionlist;
        }

        /// <summary> JOAO
        /// Leitura das transactions de uma determinada revisão.
        /// </summary>
        /// <param name="revisionID">Id de uma revisão presente na folha de dados.</param>
        /// <returns>Retrona coleção de transactions para uma revisão.</returns>
        public List<string> TransactionTypes_Reader(string revisionID)
        {
            List<string> _transactionList = new List<string>();
            for (int i = 0; i < centrifugalPumpDataSheet2().transaction2.Count; i++)
            {
                if (centrifugalPumpDataSheet2().transaction2[i].revision.First.Value.Equals(revisionID))
                {
                    _transactionList.Add(centrifugalPumpDataSheet2().transaction2[i].transactionType.First.Value);
                }
            }
            return _transactionList;
        }

        ///// <summary>
        ///// Global number: 625
        ///// API Name: Applicable to
        ///// /eqRotDoc:centrifugalPumpDataSheet/dx:dataSheetHeader/dx:dataSheetType
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="dataSheetType"></param>
        //public void DataSheetType_Writer(String dataSheetType)
        //{
        //    if (dataSheetType == null || dataSheetType.Equals(String.Empty))
        //        return;

        //    DataSheetHeader dSheetHeader = dataSheetHeader2();

        //    EDocumentTypeType.EnumValues dSheetType = cfiXML_Enums.getDataSheetType(dataSheetType);

        //    if (!dSheetHeader.dataSheetType.Exists)
        //    {
        //        // o elemento person só é criado com o elemento shortID e o shortID precisa de um valor
        //        dSheetHeader.dataSheetType.Append();
        //    }

        //    if (dSheetType.Equals(EDocumentTypeType.EnumValues.eOther) || dSheetType.Equals(EDocumentTypeType.EnumValues.ecustom))
        //    {
        //        dSheetHeader.dataSheetType.First.otherValue.Value = dataSheetType;
        //        dSheetHeader.dataSheetType.First.EnumerationValue = dSheetType;
        //    }
        //    else
        //    {
        //        dSheetHeader.dataSheetType.First.EnumerationValue = dSheetType;
        //    }

        //}

        ///// <summary>
        ///// Global number: 625
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String DataSheetType_Reader()
        //{
        //    DataSheetHeader dSheetHeader = dataSheetHeader2();

        //    if (!dSheetHeader.dataSheetType.Exists)
        //    {
        //        return null;
        //    }

        //    EDocumentTypeType.EnumValues dSheetType = dSheetHeader.dataSheetType.First.EnumerationValue;

        //    if (dSheetType.Equals(EDocumentTypeType.EnumValues.eOther) || dSheetType.Equals(EDocumentTypeType.EnumValues.ecustom))
        //    {
        //        return dSheetHeader.dataSheetType.First.otherValue.Value;
        //    }

        //    return Utils.processEnumValue(dSheetType.ToString());
        //}


        ///// <summary>
        ///// Global number: 14
        ///// API name: Applicable ntl / intntl Standard
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:pumpDesignStandard
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpDesignStandard"></param>
        //public void PumpDesignStandard_Writer(String pumpDesignStandard)
        //{
        //    if (pumpDesignStandard == null || pumpDesignStandard.Equals(String.Empty))
        //        return;

        //    eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues value = cfiXML_Enums.getPumpDesignStandard(pumpDesignStandard);

        //    eqRotDoc.eqRot.applicableStandardType4 appStandardType = applicableStandard();

        //    if (!appStandardType.pumpDesignStandard.Exists)
        //    {
        //        appStandardType.pumpDesignStandard.Append();
        //    }

        //    if (value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eOther) || value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ecustom)) // Verifiquei no xsd e invalid é usado só na programação. Diz que a varaivel ainda não foi setada.
        //    {// Tem que criar o nó other ja que o valor que vou escrever no xml nao tem no enumeration.
        //        // ver como funciona isso na norma
        //        appStandardType.pumpDesignStandard.First.EnumerationValue = value;
        //        appStandardType.pumpDesignStandard.First.otherValue.Value = pumpDesignStandard;
        //    }
        //    else
        //    {
        //        appStandardType.pumpDesignStandard.First.EnumerationValue = value;
        //    }
        //}


        ///// <summary>
        ///// Global number: 14
        ///// API name: Applicable ntl / intntl Standard
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:applicableStandard/eqRot:pumpDesignStandard
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String PumpDesignStandard_Reader()
        //{
        //    eqRotDoc.eqRot.applicableStandardType4 appStandardType = applicableStandard();

        //    if (!appStandardType.pumpDesignStandard.Exists)
        //    {
        //        return null;
        //    }

        //    eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues value = appStandardType.pumpDesignStandard.First.EnumerationValue;

        //    if (value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.eOther) || value.Equals(eqRotDoc.eqRot.EPumpDesignStandardType.EnumValues.ecustom))
        //    {
        //        return appStandardType.pumpDesignStandard.First.otherValue.Value;
        //    }

        //    return Utils.processEnumValue(value.ToString());
        //}

        ///// <summary>
        ///// Global Number 539
        ///// API Name: Site
        ///// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/objb:name
        ///// 
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="siteName"></param>
        //public void SiteName_Writer(String siteName)
        //{
        //    if (siteName == null || siteName.Equals(String.Empty))
        //        return;


        //    eqRotDoc.site.SiteFacility sFacility = siteFacility();

        //    if (!sFacility.name.Exists)
        //    {
        //        sFacility.name.Append();
        //    }

        //    sFacility.name.First.Value = siteName;
        //}


        ///// <summary>
        ///// Global Number 539
        ///// API Name: Site
        ///// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/objb:name
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String SiteName_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    eqRotDoc.site.SiteFacility sFacility = siteFacility();

        //    if (!sFacility.name.Exists)
        //    {
        //        return null;
        //    }

        //    return sFacility.name.First.Value;
        //}

        ///// <summary>
        ///// Global Number: 391
        ///// API Name: No Req
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/dx:orderLine/dx:quantity
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpQuantity"></param>
        //public void PumpQuantity_Writer(String pumpQuantity)
        //{
        //    if (pumpQuantity == null || pumpQuantity.Equals(String.Empty))
        //        return;

        //    OrderLine oLine = orderLine();

        //    if (!oLine.quantity.Exists)
        //    {
        //        oLine.quantity.Append();
        //    }

        //    oLine.quantity.First.Value = pumpQuantity;
        //}

        ///// <summary>
        ///// Global Number: 391
        ///// API Name: No Req
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/dx:orderLine/dx:quantity
        ///// </summary>
        ///// <param name="xml"></param>
        //public String PumpQuantity_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    OrderLine oLine = orderLine();

        //    if (!oLine.quantity.Exists)
        //    {
        //        return null;
        //    }

        //    return oLine.quantity.First.Value;
        //}


        ///// <summary>
        ///// Global Number: 461
        ///// API Name: Pump Size
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partSize
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpPartSize"></param>
        //public void PumpPartSize_Writer(String pumpPartSize)
        //{
        //    if (pumpPartSize == null || pumpPartSize.Equals(String.Empty))
        //        return;

        //    eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

        //    if (!cPumpID.partSize.Exists)
        //    {
        //        cPumpID.partSize.Append();
        //    }

        //    cPumpID.partSize.First.Value = pumpPartSize;
        //}

        ///// <summary>
        ///// Global Number: 461
        ///// API Name: Pump Size
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partSize
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String PumpPartSize_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

        //    if (!cPumpID.partSize.Exists)
        //    {
        //        return null;
        //    }

        //    return cPumpID.partSize.First.Value;
        //}


        ///// <summary>
        ///// Global Number: 457
        ///// API Name: Manufacturer
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/ctx:manufacturerCompany/objb:name
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpManufacturer"></param>
        //public void PumpManufacturer_Writer(String pumpManufacturer)
        //{
        //    if (pumpManufacturer == null || pumpManufacturer.Equals(String.Empty))
        //        return;

        //    Organization mCompany = manufacturerCompany();

        //    if (!mCompany.name.Exists)
        //    {
        //        mCompany.name.Append();
        //    }

        //    mCompany.name.First.Value = pumpManufacturer;
        //}

        ///// <summary>
        ///// Global Number: 457
        ///// API Name: Manufacturer
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/ctx:manufacturerCompany/objb:name
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String PumpManufacturer_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    Organization mCompany = manufacturerCompany();

        //    if (!mCompany.name.Exists)
        //    {
        //        return null;
        //    }

        //    return mCompany.name.First.Value;
        //}


        ///// <summary>
        ///// Global number: 443
        ///// API Name: Unit
        ///// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/objb:name
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="processUnit"></param>
        //public void ProcessUnit_Writer(String processUnit)
        //{
        //    if (processUnit == null || processUnit.Equals(String.Empty))
        //        return;

        //    eqRotDoc.site.FacilitySystem fSystem = facilitySystem();

        //    if (!fSystem.name.Exists)
        //    {
        //        fSystem.name.Append();
        //    }

        //    fSystem.name.First.Value = processUnit;
        //}


        ///// <summary>
        ///// Global number: 443
        ///// API Name: Unit
        ///// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/objb:name
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String ProcessUnit_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    eqRotDoc.site.FacilitySystem fSystem = facilitySystem();

        //    if (!fSystem.name.Exists)
        //    {
        //        return null;
        //    }

        //    return fSystem.name.First.Value;
        //}


        ///// <summary>
        ///// Global Number 688
        ///// API Name: Type
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partType
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpPartType"></param>
        //public void PumpPartType_Writer(String pumpPartType)
        //{
        //    if (pumpPartType == null || pumpPartType.Equals(String.Empty))
        //        return;

        //    eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

        //    if (!cPumpID.partType.Exists)
        //    {
        //        cPumpID.partType.Append();
        //    }

        //    cPumpID.partType.First.Value = pumpPartType;
        //}


        ///// <summary>
        ///// Global Number 688
        ///// API Name: Type
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:partType
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String PumpPartType_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

        //    if (!cPumpID.partType.Exists)
        //    {
        //        return null;
        //    }

        //    return cPumpID.partType.First.Value;
        //}


        ///// <summary>
        ///// Global Number 458
        ///// API Name: Model
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:model
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpModel"></param>
        //public void PumpModel_Writer(String pumpModel)
        //{
        //    if (pumpModel == null || pumpModel.Equals(String.Empty))
        //        return;

        //    eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

        //    if (!cPumpID.model.Exists)
        //    {
        //        cPumpID.model.Append();
        //    }

        //    cPumpID.model.First.Value = pumpModel;
        //}


        ///// <summary>
        ///// Global Number 458
        ///// API Name: Model
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eq:id/eq:model
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String PumpModel_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    eqRotDoc.eq.idType cPumpID = centrifugalPump_ID();

        //    if (!cPumpID.model.Exists)
        //    {
        //        return null;
        //    }

        //    return cPumpID.model.First.Value;
        //}


        ///// <summary>
        ///// Global number: 555
        ///// API Name: No Stages
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:numberStage
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpNumberOfStage"></param>
        //public void PumpNumberOfStage_Writer(String pumpNumberOfStage)
        //{
        //    if (pumpNumberOfStage == null || pumpNumberOfStage.Equals(String.Empty))
        //        return;

        //    eqRotDoc.eqRot.CentrifugalPump cPump = centrifugalPump();

        //    if (!cPump.numberStage.Exists)
        //    {
        //        cPump.numberStage.Append();
        //    }

        //    cPump.numberStage.First.Value = pumpNumberOfStage;
        //}


        ///// <summary>
        ///// Global number: 555
        ///// API Name: No Stages
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:numberStage
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String PumpNumberOfStage_Reader()
        //{
        //    if (_xml == null)
        //        return null;

        //    eqRotDoc.eqRot.CentrifugalPump cPump = centrifugalPump();

        //    if (!cPump.numberStage.Exists)
        //    {
        //        return null;
        //    }

        //    return cPump.numberStage.First.Value;
        //}


        ///// <summary>
        ///// Global number: 293
        ///// API Name: Liquid Type Or Name
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/objb:name
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidName"></param>
        //public void PumpFluidName_Writer(String pumpFluidName)
        //{
        //    if (pumpFluidName == null || pumpFluidName.Equals(String.Empty))
        //        return;
        //    eqRotDoc.uo.MaterialStream mStream = materialStream_OperatingPerformance(eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mStream.name.Exists)
        //    {
        //        mStream.name.Append();
        //    }

        //    mStream.name.First.Value = pumpFluidName;
        //}


        ///// <summary>
        ///// Global number: 293
        ///// API Name: Liquid Type Or Name
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/objb:name
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String PumpFluidName_Reader()
        //{
        //    eqRotDoc.uo.MaterialStream mStream = materialStream_OperatingPerformance(eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mStream.name.Exists)
        //    {
        //        return null;
        //    }

        //    return mStream.name.First.Value;
        //}



        ///// <summary>
        ///// Global Number: 324
        ///// API Name: Vapor Pressure - Maximum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:vaporP
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidVaporPAtMaxT"></param>
        //public void PumpFluidVaporPAtMaxT_Writer(String pumpFluidVaporPAtMaxT)
        //{

        //}

        ///// <summary>
        ///// Global Number: 349
        ///// API Name: Vapor Pressure - Minimum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:vaporP
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidVaporPAtMinT"></param>
        //public void PumpFluidVaporPAtMinT_Writer(String pumpFluidVaporPAtMinT)
        //{

        //}


        ///// <summary>
        ///// Global Number: 314
        ///// API Name: Relative Density - Maximum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:specificGravity
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidSGAtMaxT"></param>
        //public void PumpFluidSGAtMaxT_Writer(String pumpFluidSGAtMaxT)
        //{

        //}


        ///// <summary>
        ///// Global Number: 341
        ///// API Name: Relative Density - Minimum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:specificGravity
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidSGAtMinT"></param>
        //public void PumpFluidSGAtMinT_Writer(String pumpFluidSGAtMinT)
        //{

        //}

        ///// <summary>
        ///// Global Number: 550
        ///// API Name: Specific Heat - Maximum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:cpMass
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidCpMassAtMaxT"></param>
        //public void PumpFluidCpMassAtMaxT_Writer(String pumpFluidCpMassAtMaxT)
        //{

        //}

        ///// <summary>
        ///// Global Number: 346
        ///// API Name: Specific Heat - Minimum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:cpMass
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidCpMassAtMinT"></param>
        //public void PumpFluidCpMassAtMinT_Writer(String pumpFluidCpMassAtMinT)
        //{

        //}


        ///// <summary>
        ///// Global Number: 1921
        ///// API Name: Viscosity - Maximum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Max"]/mtrl:viscosity
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidDynamicViscosityAtMaxT"></param>
        //public void PumpFluidDynamicViscosityAtMaxT_Writer(String pumpFluidDynamicViscosityAtMaxT)
        //{

        //}


        ///// <summary>
        ///// Global Number: 1923
        ///// API Name: Viscosity - Minimum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Pumped Fluid Temperature, Min"]/mtrl:viscosity
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidDynamicViscosityAtMinT_Writer"></param>
        //public void PumpFluidDynamicViscosityAtMinT_Writer(String pumpFluidDynamicViscosityAtMinT_Writer)
        //{

        //}

        ///// <summary>
        ///// Global Number: 681
        ///// API Name: NPSH Datum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:npshaDatumLocation
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="nPSHAvailableDatum"></param>
        //public void NPSHAvailableDatum_Writer(String nPSHAvailableDatum)
        //{

        //}

        ///// <summary>
        ///// Global Number: 320
        ///// API Name: Pumping Temperature - Maximum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:t
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidTMax"></param>
        //public void PumpFluidTMax_Writer(String pumpFluidTMax)
        //{
        //    if (pumpFluidTMax == null || pumpFluidTMax.Equals(String.Empty))
        //        return;
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        mProperty.t.Append();
        //    }

        //    mProperty.t.First.Value = pumpFluidTMax;
        //    mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Max";

        //}

        ///// <summary>
        ///// Global Number: 320
        ///// API Name: Pumping Temperature - Maximum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Maximum"]/mtrl:t
        ///// </summary>
        ///// <returns></returns>
        //public String PumpFluidTMax_Reader()
        //{
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMaximum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        return null;
        //    }

        //    return mProperty.t.First.Value;

        //}

        ///// <summary>
        ///// Global Number: 452
        ///// API Name: Pumping Temperature - Reated
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Rated"]/mtrl:t
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidTRated"></param>
        //public void PumpFluidTRated_Writer(String pumpFluidTRated)
        //{
        //    if (pumpFluidTRated == null || pumpFluidTRated.Equals(String.Empty))
        //        return;
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        mProperty.t.Append();
        //    }

        //    mProperty.t.First.Value = pumpFluidTRated;
        //    mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Rated";
        //}

        ///// <summary>
        ///// Global Number: 452
        ///// API Name: Pumping Temperature - Reated
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Rated"]/mtrl:t
        ///// </summary>
        ///// <returns></returns>
        //public String PumpFluidTRated_Reader()
        //{
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eRated, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        return null;
        //    }

        //    return mProperty.t.First.Value;
        //}

        ///// <summary>
        ///// Global Number: 375
        ///// API Name: Pumping Temperature - Normal
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:t
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidTNormal"></param>
        //public void PumpFluidTNormal_Writer(String pumpFluidTNormal)
        //{
        //    if (pumpFluidTNormal == null || pumpFluidTNormal.Equals(String.Empty))
        //        return;
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        mProperty.t.Append();
        //    }

        //    mProperty.t.First.Value = pumpFluidTNormal;
        //    mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Normal";
        //}


        ///// <summary>
        ///// Global Number: 375
        ///// API Name: Pumping Temperature - Normal
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Normal"]/mtrl:t
        ///// </summary>
        ///// <returns></returns>
        //public String PumpFluidTNormal_Reader()
        //{
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eNormal, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        return null;
        //    }

        //    return mProperty.t.First.Value;
        //}


        ///// <summary>
        ///// Global Number: 345
        ///// API Name: Pumping Temperature - Minimum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:t
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="pumpFluidTMin"></param>
        //public void PumpFluidTMin_Writer(String pumpFluidTMin)
        //{
        //    if (pumpFluidTMin == null || pumpFluidTMin.Equals(String.Empty))
        //        return;
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        mProperty.t.Append();
        //    }

        //    mProperty.t.First.Value = pumpFluidTMin;
        //    mProperty.t.First.referencePropertyID.Value = "Pumped Fluid Temperature, Min";
        //}


        ///// <summary>
        ///// Global Number: 345
        ///// API Name: Pumping Temperature - Minimum
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/etl:propertyType="Minimum"]/mtrl:t
        ///// </summary>
        ///// <returns></returns>
        //public String PumpFluidTMin_Reader()
        //{
        //    eqRotDoc.mtrl.propertyType2 mProperty = mtrl_property_With_context_PropertyType(eqRotDoc.etl.EPropertyTypeType.EnumValues.eMinimum, eqRotDoc.etl.ENormalFlowDirectionType.EnumValues.eInlet);

        //    if (!mProperty.t.Exists)
        //    {
        //        return null;
        //    }

        //    return mProperty.t.First.Value;
        //}

        ///// <summary>
        ///// Global Number: 147
        ///// API Name: Discharge Pressure - Reated
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Outlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Flowrate, Rated"]/mtrl:p
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="dischargePRated"></param>
        //public void DischargePRated_Writer(String dischargePRated)
        //{
        //    //referenceProperty
        //}

        ///// <summary>
        ///// Global number: 418
        ///// API name: Pumps Operate In
        ///// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/site:equipmentSet/site:equipmentConfiguration/site:configurationType
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <param name="operatingConfiguration"></param>
        //public void OperatingConfiguration_Writer(String operatingConfiguration)
        //{
        //    if (operatingConfiguration == null || operatingConfiguration.Equals(String.Empty))
        //        return;

        //    eqRotDoc.site.EConfigurationTypeType.EnumValues value = cfiXML_Enums.getOperatingConfigurationType(operatingConfiguration);


        //    eqRotDoc.site.EquipmentConfiguration equiConf = equipmentConfiguration();

        //    if (!equiConf.configurationType.Exists)
        //    {
        //        equiConf.configurationType.Append();
        //    }

        //    if (value.Equals(eqRotDoc.site.EConfigurationTypeType.EnumValues.ecustom))
        //    {// Tem que criar o nó other ja que o valor que vou escrever no xml nao tem no enumeration.
        //        equiConf.configurationType.First.EnumerationValue = value;
        //        equiConf.configurationType.First.otherValue.Value = operatingConfiguration;
        //    }
        //    else
        //    {
        //        equiConf.configurationType.First.EnumerationValue = value;
        //    }

        //}

        ///// <summary>
        ///// Global number: 418
        ///// API name: Pumps Operate In
        ///// /eqRotDoc:centrifugalPumpDataSheet/site:siteFacility/site:facilitySystem/site:equipmentSet/site:equipmentConfiguration/site:configurationType
        ///// </summary>
        ///// <param name="xml"></param>
        ///// <returns></returns>
        //public String OperatingConfiguration_Reader()
        //{
        //    eqRotDoc.site.EquipmentConfiguration equiConf = equipmentConfiguration();

        //    if (!equiConf.configurationType.Exists)
        //    {
        //        return null;
        //    }

        //    eqRotDoc.site.EConfigurationTypeType.EnumValues value = equiConf.configurationType.First.EnumerationValue;

        //    if (value.Equals(eqRotDoc.site.EConfigurationTypeType.EnumValues.ecustom))
        //    {
        //        return equiConf.configurationType.First.otherValue.Value;
        //    }

        //    return Utils.processEnumValue(value.ToString());
        //}

        ///// <summary>
        ///// Global number: 482
        ///// API name: Suction Pressure - Reated
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Flowrate, Rated"]/mtrl:p[@basis="absolute"]
        ///// </summary>
        ///// <param name="suctionPRated"></param>
        //public void SuctionPRated_Writer(String suctionPRated)
        //{
        //    //referenceProperty
        //}

        ///// <summary>
        ///// Global number: 482
        ///// API name: Suction Pressure - Reated
        ///// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:streamConnection[@usageContext="Operating performance"][etl:normalFlowDirection="Inlet"]/uo:materialStream/mtrl:materialProperty/mtrl:property[mtrl:context/mtrl:referenceProperty="Flowrate, Rated"]/mtrl:p[@basis="absolute"]
        ///// </summary>
        ///// <returns></returns>
        //public String SuctionPRated_Reader()
        //{
        //    //referenceProperty
        //    return null;
        //}

        /// <summary>
        /// /eqRotDoc:centrifugalPumpDataSheet/eqRot:centrifugalPump/eqRot:pressureDifference[@usageContext="args1"][@propertyType="args2"]
        /// </summary>
        /// <param name="usageContext"></param>
        /// <param name="propertyType"></param>
        /// <returns></returns>
        private eqRotDoc.eqRot.pressureDifferenceType2 PressureDifference(eqRotDoc.ext.EUsageContext.EnumValues usageContext, eqRotDoc.etl.EPropertyType.EnumValues propertyType)
        {
            eqRotDoc.eqRot.CentrifugalPump cPump = centrifugalPump();

            if (cPump.pressureDifference.Exists)
            {
                for (int i = 0; i < cPump.pressureDifference.Count; i++)
                {
                    if (cPump.pressureDifference[i].propertyType.EnumerationValue.Equals(propertyType) && cPump.pressureDifference[i].usageContext.EnumerationValue.Equals(usageContext))
                    {
                        return cPump.pressureDifference[i];
                    }
                }
            }
            eqRotDoc.eqRot.pressureDifferenceType2 pDiff = cPump.pressureDifference.Append();
            pDiff.propertyType.EnumerationValue = propertyType;
            pDiff.usageContext.EnumerationValue = usageContext;
            return pDiff;
        }
    }
}
