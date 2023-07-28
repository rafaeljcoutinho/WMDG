using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    #region Material List For Pistols
    [System.Serializable]
    public class Materials
    {
        public Material MainBody;
        public Material MagAndReloderOrChamber;
        public Material Parts;
    }
    #endregion

    #region Disert Egal Variabler
    [Range(1, 4)]
    public int DisertEgalTextureIndex = 1;
    public List<Materials> DisertEgalMaterials = new List<Materials>();
    private Transform DisertEgal;
    private Transform DEMAINBODY;
    private Transform DERELODER;
    private Transform DEPART;
    private Transform DEPART2;
    private Transform DEPART3;
    private Transform DEPART4;
    private Transform MAG;
    #endregion

    #region GLOCK G22 Variables
    [Range(1, 4)]
    public int GlockG22TexturesIndex = 1;
    public List<Materials> GlockG22Materials = new List<Materials>();
    private Transform GlockG22;
    private Transform GMainBody;
    private Transform GPART;
    private Transform GPART2;
    private Transform GRELODER;
    private Transform GMAG;
    private Transform GPART3;
    private Transform GPART4;
    #endregion

    #region S&W 357 Vatiables
    [Range(1,4)]
    public int SAndW357TextureIndex = 1;
    public List<Materials> SAndW357Materials = new List<Materials>();
    private Transform SAndW357;
    private Transform SMAINBODY;
    private Transform SCHAMBER;
    private Transform SPART;
    private Transform SPART2;
    private Transform SPART3;
    private Transform SPART4;
    private Transform SPART5;
    #endregion

    #region S&W 500
    [Range(1, 4)]
    public int SAndW500TextureIndex = 1;
    public List<Materials> SAndW500Materials = new List<Materials>();
    private Transform SAndW500;
    private Transform SWMAINBODY;
    private Transform SWCHAMBER;
    private Transform SWPART;
    private Transform SWPART2;
    private Transform SWPART3;
    private Transform SWPART4;
    private Transform SWPART5;
    #endregion

    void Start()
    {
        #region Disert Egal
        DisertEgal = GameObject.Find("Disert Egal 50 CAL").GetComponent<Transform>();
        DEMAINBODY = DisertEgal.transform.Find("MainBody");
        DERELODER = DisertEgal.transform.Find("RELODER");
        DEPART = DisertEgal.transform.Find("PART");
        DEPART2 = DisertEgal.transform.Find("PART2");
        DEPART3 = DisertEgal.transform.Find("PART3");
        DEPART4 = DisertEgal.transform.Find("PART4");
        MAG = DisertEgal.transform.Find("MAG");
        #endregion

        #region GLOCK G22
        GlockG22 = GameObject.Find("Glock G22").GetComponent<Transform>();
        GMainBody = GlockG22.transform.Find("MainBody");
        GPART = GlockG22.transform.Find("PART");
        GPART2 = GlockG22.transform.Find("PART2");
        GPART3 = GlockG22.transform.Find("PART3");
        GPART4 = GlockG22.transform.Find("PART4");
        GRELODER = GlockG22.transform.Find("RELODER");
        GMAG = GlockG22.transform.Find("MAG");
        #endregion

        #region S&W 357
        SAndW357 = GameObject.Find("S & W 357").GetComponent<Transform>();
        SMAINBODY = SAndW357.transform.Find("MainBody");
        SCHAMBER = SAndW357.transform.Find("Chamber");
        SPART = SAndW357.transform.Find("PART");
        SPART2 = SAndW357.transform.Find("PART2");
        SPART3 = SAndW357.transform.Find("PART3");
        SPART4 = SAndW357.transform.Find("PART4");
        SPART5 = SAndW357.transform.Find("PART5");
        #endregion

        #region S&W 500
        SAndW500 = GameObject.Find("S & W 500").GetComponent<Transform>();
        SWMAINBODY = SAndW500.transform.Find("MainBody");
        SWCHAMBER = SAndW500.transform.Find("Chamber");
        SWPART = SAndW500.transform.Find("PART");
        SWPART2 = SAndW500.transform.Find("PART2");
        SWPART3 = SAndW500.transform.Find("PART3");
        SWPART4 = SAndW500.transform.Find("PART4");
        SWPART5 = SAndW500.transform.Find("PART5");
        #endregion

    }


    void Update()
    {
        #region Disert Egal
        if(DisertEgalTextureIndex == 1)
        {
            DEMAINBODY.GetComponent<MeshRenderer>().material = DisertEgalMaterials[0].MainBody;
            DERELODER.GetComponent<MeshRenderer>().material = DisertEgalMaterials[0].MagAndReloderOrChamber;
            DEPART.GetComponent<MeshRenderer>().material = DisertEgalMaterials[0].Parts;
            DEPART2.GetComponent<MeshRenderer>().material = DisertEgalMaterials[0].Parts;
            DEPART3.GetComponent<MeshRenderer>().material = DisertEgalMaterials[0].Parts;
            DEPART4.GetComponent<MeshRenderer>().material = DisertEgalMaterials[0].Parts;
            MAG.GetComponent<MeshRenderer>().material = DisertEgalMaterials[0].MagAndReloderOrChamber;
        }
        if (DisertEgalTextureIndex == 2)
        {
            DEMAINBODY.GetComponent<MeshRenderer>().material = DisertEgalMaterials[1].MainBody;
            DERELODER.GetComponent<MeshRenderer>().material = DisertEgalMaterials[1].MagAndReloderOrChamber;
            DEPART.GetComponent<MeshRenderer>().material = DisertEgalMaterials[1].Parts;
            DEPART2.GetComponent<MeshRenderer>().material = DisertEgalMaterials[1].Parts;
            DEPART3.GetComponent<MeshRenderer>().material = DisertEgalMaterials[1].Parts;
            DEPART4.GetComponent<MeshRenderer>().material = DisertEgalMaterials[1].Parts;
            MAG.GetComponent<MeshRenderer>().material = DisertEgalMaterials[1].MagAndReloderOrChamber;
        }
        if (DisertEgalTextureIndex == 3)
        {
            DEMAINBODY.GetComponent<MeshRenderer>().material = DisertEgalMaterials[2].MainBody;
            DERELODER.GetComponent<MeshRenderer>().material = DisertEgalMaterials[2].MagAndReloderOrChamber;
            DEPART.GetComponent<MeshRenderer>().material = DisertEgalMaterials[2].Parts;
            DEPART2.GetComponent<MeshRenderer>().material = DisertEgalMaterials[2].Parts;
            DEPART3.GetComponent<MeshRenderer>().material = DisertEgalMaterials[2].Parts;
            DEPART4.GetComponent<MeshRenderer>().material = DisertEgalMaterials[2].Parts;
            MAG.GetComponent<MeshRenderer>().material = DisertEgalMaterials[2].MagAndReloderOrChamber;
        }
        if (DisertEgalTextureIndex == 4)
        {
            DEMAINBODY.GetComponent<MeshRenderer>().material = DisertEgalMaterials[3].MainBody;
            DERELODER.GetComponent<MeshRenderer>().material = DisertEgalMaterials[3].MagAndReloderOrChamber;
            DEPART.GetComponent<MeshRenderer>().material = DisertEgalMaterials[3].Parts;
            DEPART2.GetComponent<MeshRenderer>().material = DisertEgalMaterials[3].Parts;
            DEPART3.GetComponent<MeshRenderer>().material = DisertEgalMaterials[3].Parts;
            DEPART4.GetComponent<MeshRenderer>().material = DisertEgalMaterials[3].Parts;
            MAG.GetComponent<MeshRenderer>().material = DisertEgalMaterials[3].MagAndReloderOrChamber;
        }
        #endregion

        #region GLOCK G22
        if(GlockG22TexturesIndex == 1)
        {
            GMainBody.GetComponent<MeshRenderer>().material = GlockG22Materials[0].MainBody;
            GRELODER.GetComponent<MeshRenderer>().material = GlockG22Materials[0].MagAndReloderOrChamber;
            GMAG.GetComponent<MeshRenderer>().material = GlockG22Materials[0].MagAndReloderOrChamber;
            GPART.GetComponent<MeshRenderer>().material = GlockG22Materials[0].Parts;
            GPART2.GetComponent<MeshRenderer>().material = GlockG22Materials[0].Parts;
            GPART3.GetComponent<MeshRenderer>().material = GlockG22Materials[0].Parts;
            GPART4.GetComponent<MeshRenderer>().material = GlockG22Materials[0].Parts;
        }
        if (GlockG22TexturesIndex == 2)
        {
            GMainBody.GetComponent<MeshRenderer>().material = GlockG22Materials[1].MainBody;
            GRELODER.GetComponent<MeshRenderer>().material = GlockG22Materials[1].MagAndReloderOrChamber;
            GMAG.GetComponent<MeshRenderer>().material = GlockG22Materials[1].MagAndReloderOrChamber;
            GPART.GetComponent<MeshRenderer>().material = GlockG22Materials[1].Parts;
            GPART2.GetComponent<MeshRenderer>().material = GlockG22Materials[1].Parts;
            GPART3.GetComponent<MeshRenderer>().material = GlockG22Materials[1].Parts;
            GPART4.GetComponent<MeshRenderer>().material = GlockG22Materials[1].Parts;
        }
        if (GlockG22TexturesIndex == 3)
        {
            GMainBody.GetComponent<MeshRenderer>().material = GlockG22Materials[2].MainBody;
            GRELODER.GetComponent<MeshRenderer>().material = GlockG22Materials[2].MagAndReloderOrChamber;
            GMAG.GetComponent<MeshRenderer>().material = GlockG22Materials[2].MagAndReloderOrChamber;
            GPART.GetComponent<MeshRenderer>().material = GlockG22Materials[2].Parts;
            GPART2.GetComponent<MeshRenderer>().material = GlockG22Materials[2].Parts;
            GPART3.GetComponent<MeshRenderer>().material = GlockG22Materials[2].Parts;
            GPART4.GetComponent<MeshRenderer>().material = GlockG22Materials[2].Parts;
        }
        if (GlockG22TexturesIndex == 4)
        {
            GMainBody.GetComponent<MeshRenderer>().material = GlockG22Materials[3].MainBody;
            GRELODER.GetComponent<MeshRenderer>().material = GlockG22Materials[3].MagAndReloderOrChamber;
            GMAG.GetComponent<MeshRenderer>().material = GlockG22Materials[3].MagAndReloderOrChamber;
            GPART.GetComponent<MeshRenderer>().material = GlockG22Materials[3].Parts;
            GPART2.GetComponent<MeshRenderer>().material = GlockG22Materials[3].Parts;
            GPART3.GetComponent<MeshRenderer>().material = GlockG22Materials[3].Parts;
            GPART4.GetComponent<MeshRenderer>().material = GlockG22Materials[3].Parts;
        }
        #endregion

        #region S&W 357
        if (SAndW357TextureIndex == 1)
        {
            SMAINBODY.GetComponent<MeshRenderer>().material = SAndW357Materials[0].MainBody;
            SCHAMBER.GetComponent<MeshRenderer>().material = SAndW357Materials[0].MagAndReloderOrChamber;
            SPART.GetComponent<MeshRenderer>().material = SAndW357Materials[0].Parts;
            SPART2.GetComponent<MeshRenderer>().material = SAndW357Materials[0].Parts;
            SPART3.GetComponent<MeshRenderer>().material = SAndW357Materials[0].Parts;
            SPART4.GetComponent<MeshRenderer>().material = SAndW357Materials[0].Parts;
            SPART5.GetComponent<MeshRenderer>().material = SAndW357Materials[0].Parts;
        }
        if (SAndW357TextureIndex == 2)
        {
            SMAINBODY.GetComponent<MeshRenderer>().material = SAndW357Materials[1].MainBody;
            SCHAMBER.GetComponent<MeshRenderer>().material = SAndW357Materials[1].MagAndReloderOrChamber;
            SPART.GetComponent<MeshRenderer>().material = SAndW357Materials[1].Parts;
            SPART2.GetComponent<MeshRenderer>().material = SAndW357Materials[1].Parts;
            SPART3.GetComponent<MeshRenderer>().material = SAndW357Materials[1].Parts;
            SPART4.GetComponent<MeshRenderer>().material = SAndW357Materials[1].Parts;
            SPART5.GetComponent<MeshRenderer>().material = SAndW357Materials[1].Parts;
        }
        if (SAndW357TextureIndex == 3)
        {
            SMAINBODY.GetComponent<MeshRenderer>().material = SAndW357Materials[2].MainBody;
            SCHAMBER.GetComponent<MeshRenderer>().material = SAndW357Materials[2].MagAndReloderOrChamber;
            SPART.GetComponent<MeshRenderer>().material = SAndW357Materials[2].Parts;
            SPART2.GetComponent<MeshRenderer>().material = SAndW357Materials[2].Parts;
            SPART3.GetComponent<MeshRenderer>().material = SAndW357Materials[2].Parts;
            SPART4.GetComponent<MeshRenderer>().material = SAndW357Materials[2].Parts;
            SPART5.GetComponent<MeshRenderer>().material = SAndW357Materials[2].Parts;
        }
        if (SAndW357TextureIndex == 4)
        {
            SMAINBODY.GetComponent<MeshRenderer>().material = SAndW357Materials[3].MainBody;
            SCHAMBER.GetComponent<MeshRenderer>().material = SAndW357Materials[3].MagAndReloderOrChamber;
            SPART.GetComponent<MeshRenderer>().material = SAndW357Materials[3].Parts;
            SPART2.GetComponent<MeshRenderer>().material = SAndW357Materials[3].Parts;
            SPART3.GetComponent<MeshRenderer>().material = SAndW357Materials[3].Parts;
            SPART4.GetComponent<MeshRenderer>().material = SAndW357Materials[3].Parts;
            SPART5.GetComponent<MeshRenderer>().material = SAndW357Materials[3].Parts;
        }
        #endregion

        #region S&W 500
        if(SAndW500TextureIndex == 1)
        {
            SWMAINBODY.GetComponent<MeshRenderer>().material = SAndW500Materials[0].MainBody;
            SWCHAMBER.GetComponent<MeshRenderer>().material = SAndW500Materials[0].MagAndReloderOrChamber;
            SWPART.GetComponent<MeshRenderer>().material = SAndW500Materials[0].Parts;
            SWPART2.GetComponent<MeshRenderer>().material = SAndW500Materials[0].Parts;
            SWPART3.GetComponent<MeshRenderer>().material = SAndW500Materials[0].Parts;
            SWPART4.GetComponent<MeshRenderer>().material = SAndW500Materials[0].Parts;
            SWPART5.GetComponent<MeshRenderer>().material = SAndW500Materials[0].Parts;
        }
        if (SAndW500TextureIndex == 2)
        {
            SWMAINBODY.GetComponent<MeshRenderer>().material = SAndW500Materials[1].MainBody;
            SWCHAMBER.GetComponent<MeshRenderer>().material = SAndW500Materials[1].MagAndReloderOrChamber;
            SWPART.GetComponent<MeshRenderer>().material = SAndW500Materials[1].Parts;
            SWPART2.GetComponent<MeshRenderer>().material = SAndW500Materials[1].Parts;
            SWPART3.GetComponent<MeshRenderer>().material = SAndW500Materials[1].Parts;
            SWPART4.GetComponent<MeshRenderer>().material = SAndW500Materials[1].Parts;
            SWPART5.GetComponent<MeshRenderer>().material = SAndW500Materials[1].Parts;
        }
        if (SAndW500TextureIndex == 3)
        {
            SWMAINBODY.GetComponent<MeshRenderer>().material = SAndW500Materials[2].MainBody;
            SWCHAMBER.GetComponent<MeshRenderer>().material = SAndW500Materials[2].MagAndReloderOrChamber;
            SWPART.GetComponent<MeshRenderer>().material = SAndW500Materials[2].Parts;
            SWPART2.GetComponent<MeshRenderer>().material = SAndW500Materials[2].Parts;
            SWPART3.GetComponent<MeshRenderer>().material = SAndW500Materials[2].Parts;
            SWPART4.GetComponent<MeshRenderer>().material = SAndW500Materials[2].Parts;
            SWPART5.GetComponent<MeshRenderer>().material = SAndW500Materials[2].Parts;
        }
        if (SAndW500TextureIndex == 4)
        {
            SWMAINBODY.GetComponent<MeshRenderer>().material = SAndW500Materials[3].MainBody;
            SWCHAMBER.GetComponent<MeshRenderer>().material = SAndW500Materials[3].MagAndReloderOrChamber;
            SWPART.GetComponent<MeshRenderer>().material = SAndW500Materials[3].Parts;
            SWPART2.GetComponent<MeshRenderer>().material = SAndW500Materials[3].Parts;
            SWPART3.GetComponent<MeshRenderer>().material = SAndW500Materials[3].Parts;
            SWPART4.GetComponent<MeshRenderer>().material = SAndW500Materials[3].Parts;
            SWPART5.GetComponent<MeshRenderer>().material = SAndW500Materials[3].Parts;
        }
        #endregion
    }
}
