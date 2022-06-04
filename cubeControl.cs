using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cubeControl : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI seconds;
    Transform playerBody;
    CharacterController contr;
    public float speed=12f;
    float graValue =-4.81f;
    int time =15;
    bool isGrounded=false;
    public GameObject loose;
    public GameObject win;
    public GameObject panel;
    public GameObject crown;

    void Start()
    {
        InvokeRepeating("timeMinus",1f,1f);
        playerBody=GetComponent<Transform>();
        contr=GetComponent<CharacterController>();
    }

    void Update()
    {
        float mouseX=Input.GetAxis("Mouse X");
        float vertical=Input.GetAxis("Vertical");
        contr.Move(playerBody.up*graValue*Time.deltaTime);
        contr.Move(playerBody.forward*vertical*speed*Time.deltaTime);

        playerBody.Rotate(0,mouseX,0);
        if(Input.GetKeyDown("space") && isGrounded==true){
            contr.Move(playerBody.up*5f);
        }
        else{
            isGrounded=false;
        }
    }
    void OnMouseDown(){
        
    }
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag=="ground"){
            isGrounded=true;
        }
        if(col.gameObject.tag=="finish"){
            print("Win");
            win.SetActive(true);
            crown.SetActive(true);
            CancelInvoke();
        }
    }
    void timeMinus(){
        time=time-1;
        seconds.text=time+" sec";
        print(time);
        if(time==0){
            print("Lose");
            CancelInvoke();
            graValue=0;
            speed=0;
            loose.SetActive(true);
        }
    }

}