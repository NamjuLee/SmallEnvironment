using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Landscape : MonoBehaviour {

    public static bool landPixelpBool = false;

    public static string type = "";
    public static float creationExecutionFloat = 0.0f;
    public static bool creationExecutionBool = false;


    public GameObject Building_A_Master;
    public Text landscapeLog;
    public float pixelRes;

    public PixelMap pixelMap;

    Button btnPixp;

    void Awake() {
        btnPixp = GameObject.Find("ui_Lat").GetComponent<Button>();
        landscapeLog = GameObject.Find("LandscapeLog").GetComponent<Text>();
        pixelMap = new PixelMap();
        pixelMap.Build(new Vector3(-pixelRes, 0f,-pixelRes), new Vector3(pixelRes, 0f, pixelRes), 15,15 );
        if (landp == null) landp = GameObject.FindGameObjectWithTag("landp");
        

    }

    

    public GameObject landp;
	// Use this for initialization
	void Start () {
        
        landp.transform.localScale = new Vector3(pixelMap.ddx, 0.01f, pixelMap.ddz);
	
	}
	
	// Update is called once per frame
	void Update () {

        Raycasting();
        GetLandObject();
        Landscape.creationExecutionFloat += 0.05f;
        UpdateEachPixelFromObjectData();
       // VisEachPixelFromObjectData();
    }





    void OnMouseUp()
    {
        if (Landscape.creationExecutionFloat > 1.0f) Landscape.creationExecutionBool = true;
    }

    void OnMouseDown()
    {
        // Raycasting();
        // Debug.Log(pixSelected.pmid.x.ToString()  + " --  " +  pixSelected.pmid.z.ToString());
    }

    GameObject g;
    void GetLandObject() {
        if (Input.GetMouseButtonDown(0))
        {
            if ((type == "buildingA") && (Landscape.creationExecutionBool) && ((UIText.Money - 450) > 0))
            {
                g = Instantiate(Building_A_Master, hit.point, Quaternion.identity) as GameObject;
                type = "";
                Landscape.creationExecutionBool = false;

                UIText.Money -= 450;
            }
        }
       
    }

    public Pixel pixSelected;
    private RaycastHit hit;
    public void Raycasting()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Input.GetMouseButtonDown(0))
        // {
        if (Physics.Raycast(ray, out hit))
        {
            pixSelected = pixelMap.GetPixelAtPoint(hit.point);
            Debug.Log(pixSelected.pmid);



            pixSelected.pmid.y = 0.04f;
            if (Landscape.landPixelpBool)
            {
                landp.transform.position = pixSelected.pmid;
                landp.transform.Translate(0,-0.5f,0);
                landscapeLog.text = "is Tree : " + pixSelected.isTree + "\n" +
                                    "is Water: " + pixSelected.isWater + "\n" +
                                    "is Building: " + pixSelected.isBuilding + "\n" +
                                    "is Factory: " + pixSelected.isFactory + "\n";
            }
            else
            {
                landp.transform.position = new Vector3(0f, -15f, 0f);
            }
        }
       // }
    }


    GameObject[] waters;
    public void UpdateEachPixelFromObjectData()
    {
        waters = GameObject.FindGameObjectsWithTag("water");
        foreach (GameObject g in waters ) {
            Pixel p = pixelMap.GetPixelAtPoint(g.transform.position);
            p.isWater = true;
        }

        foreach (GameObject g in Tree.treeList)
        {
            Pixel p = pixelMap.GetPixelAtPoint(g.transform.position);
            p.isTree  = true;
        }
        foreach (GameObject g in Building_A.BuildingAList)
        {
            Pixel p = pixelMap.GetPixelAtPoint(g.transform.position);
            p.isBuilding = true;
        }
        foreach (GameObject g in Factory.factoryList)
        {
            Pixel p = pixelMap.GetPixelAtPoint(g.transform.position);
            p.isFactory = true;
        }
    }

    //VisEachPixelFromObjectData();



    public class Pixel
    {
        public float occupancy = 0.0f;
        public float friction = 0.0f;

        public float shadowness = 0.0f;
        public float dampness = 0.0f;
        public float slopeness = 0.0f;

        public bool isWater = false;
        public bool isTree = false;
        public bool isBuilding = false;
        public bool isFactory = false;
        public bool isSolid = false;

        public Vector3 staticFlow = Vector3.zero;
        public Vector3 flow = Vector3.zero;
        public Vector3 p0;
        public Vector3 p1;
        public Vector3 pmid;

        public int i, j;
        public List<Pixel> npix = new List<Pixel>();

    }

        public class PixelMap
        {
            public List<Pixel> pixels = new List<Pixel>();

            //public Crowd crowd;

            int rx = 0;
            int rz = 0;
            public float ddx = 0.0f;
            public float ddz = 0.0f;
            public Vector3 P0;
            public Vector3 P1;

            public Random rnd = new Random();

            public void Build(Vector3 p0, Vector3 p1, int rx, int rz)
            {
                pixels.Clear();
                this.rx = rx;
                this.rz = rz;
                P0 = p0;
                P1 = p1;
                ddx = (p1.x - p0.x) / (float)(rx - 1.0);
                ddz = (p1.z - p0.z) / (float)(rz - 1.0);

                InitGrid();
                InitGridNeighbor();
            } 
        

        public void InitGrid()
        {
            for (int j = 0; j < rz; ++j)
            {
                for (int i = 0; i < rx; ++i)
                {
                    float x = P0.x + i * ddx;
                    float z = P0.z + j * ddz;
                    Pixel px = new Pixel();
                    px.i = i;
                    px.j = j;
                    px.pmid = new Vector3(x, 0.0f, z);
                    px.p0 = new Vector3(x - ddx * 0.5f, 0.0f, z - ddz * 0.5f);
                    px.p1 = new Vector3(x + ddx * 0.5f, 0.0f, z + ddz * 0.5f);
                    pixels.Add(px);
                }
            }
        }
        public void InitGridNeighbor()
        {
            for (int j = 0; j < rz; ++j)
            {
                for (int i = 0; i < rx; ++i)
                {
                    int k = j * rx + i;
                    Pixel px0 = pixels[k];

                    if (i > 0) px0.npix.Add(pixels[k - 1]);
                    if (i < rx - 1) px0.npix.Add(pixels[k + 1]);
                    if (j > 0) px0.npix.Add(pixels[k - rx]);
                    if (j < rz - 1) px0.npix.Add(pixels[k + rx]);

                    if ((i > 0) && (j < rz - 1)) px0.npix.Add(pixels[k + rx - 1]);
                    if ((i > 0) && (j > 0)) px0.npix.Add(pixels[k - rx - 1]);
                    if ((i < rx - 1) && (j < rz - 1)) px0.npix.Add(pixels[k + rx + 1]);
                    if ((i < rx - 1) && (j > 0)) px0.npix.Add(pixels[k - rx + 1]);
                }
            }
        }
        #region map utility
        public Pixel GetPixelWithIJ(int i, int j) {
            return pixels[j * rx + i];

        }
        public Pixel GetPixelAtPoint(Vector3 pt)
        {
            Vector3 dp = pt - P0;

            int i = (int)(Mathf.Round(dp.x / ddx));
            int j = (int)(Mathf.Round(dp.z / ddz));

            if (i >= rx) i = rx - 1;
            if (j >= rz) j = rz - 1;
            if (i < 0) i = 0;
            if (j < 0) j = 0;

            return pixels[j * rx + i];
        }
        public Vector3 GetPtAtPoint(Vector3 pt)
        {
            Vector3 dp = pt - P0;

            int i = (int)(Mathf.Round(dp.x / ddx));
            int j = (int)(Mathf.Round(dp.z / ddz));

            if (i >= rx) i = rx - 1;
            if (j >= rz) j = rz - 1;
            if (i < 0) i = 0;
            if (j < 0) j = 0;

            return pixels[j * rz + i].pmid;
        }
        #endregion  map utility








    }
}
