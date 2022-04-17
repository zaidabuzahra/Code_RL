using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QT_Events : MonoBehaviour
{
    public Sprite ButtonLogo_W;
    public Sprite ButtonLogo_S;
    public Sprite ButtonLogo_A;
    public Sprite ButtonLogo_D;

    public Sprite ButtonLogo_WGreen;
    public Sprite ButtonLogo_SGreen;
    public Sprite ButtonLogo_AGreen;
    public Sprite ButtonLogo_DGreen;

    public Sprite ButtonLogo_WRed;
    public Sprite ButtonLogo_SRed;
    public Sprite ButtonLogo_ARed;
    public Sprite ButtonLogo_DRed;

    public Image UIImage;
    public Image ShrinkingImage;
    public GameObject MainMenu;

    private int RandomXPosition;
    private int RandomYPosition;

    public float SetTimer;
    private int LetterChoice;
    public float Timer;
    private int RandomLetter;
    private int Check = 0;
    private bool bCanPress = true;
    private bool bUpdate = true;

    public AudioClip RightButtonAudio;
    public AudioClip WrongButtonAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        { 
            if (Input.GetButtonDown("Esc"))
            {
                bUpdate = false;
                MainMenu.SetActive(true);
            }
        }

        if (!bUpdate)
        {
            if (!MainMenu.GetComponent<RawImage>().IsActive())
            {
                bUpdate = true;
            }
        }

        if (bUpdate)
        {
            Timer -= Time.deltaTime;
            if (Check == 0)
            {
                LetterChoice = ChosenLetter();
                Timer = SetTimer;
                Check = 1;
            }

            if (bCanPress)
            {
                if (Timer <= SetTimer)
                {
                    ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(1 + Timer, 1 + Timer, 0);

                    if (LetterChoice == 1)
                    {
                        if (Input.anyKeyDown)
                        {
                            if (Input.GetButtonDown("AKey"))
                            {
                                ShowLetter();
                            }

                            else
                            {
                                WrongA();
                            }
                        }
                    }

                    if (LetterChoice == 2)
                    {
                        if (Input.anyKeyDown)
                        {
                            if (Input.GetButtonDown("DKey"))
                            {
                                ShowLetter();
                            }

                            else
                            {
                                WrongA();
                            }
                        }
                    }

                    if (LetterChoice == 3)
                    {
                        if (Input.anyKeyDown)
                        {
                            if (Input.GetButtonDown("SKey"))
                            {
                                ShowLetter();
                            }
                            else
                            {
                                WrongA();
                            }
                        }
                    }

                    if (LetterChoice == 4)
                    {
                        if (Input.anyKeyDown)
                        {
                            if (Input.GetButtonDown("WKey"))
                            {
                                ShowLetter();
                            }

                            else
                            {
                                WrongA();
                            }
                        }
                    }
                }
                if (Timer <= 0)
                {
                    Timer = SetTimer;
                    WrongA();
                }
            }
        }
    }

    public int ChosenLetter()
    {
        RandomLetter = Random.Range(1, 5);
        RandomYPosition = Random.Range(50, 930);
        RandomXPosition = Random.Range(50, 1770);

        UIImage.GetComponent<Image>().transform.position = new Vector3(RandomXPosition, RandomYPosition, 0); 

        if (RandomLetter == 1)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_A;
            return 1;
        }

        if (RandomLetter == 2)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_D;
            return 2;
        }

        if (RandomLetter == 3)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_S;
            return 3;
        }

        if (RandomLetter == 4)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_W;
            return 4;
        }

        return 5;
    }

    public void ShowLetter()
    {
        bCanPress = false;

       
        if (LetterChoice == 1)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_AGreen;
        }

        if (LetterChoice == 2)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_DGreen;
        }

        if (LetterChoice == 3)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_SGreen;
        }

        if (LetterChoice == 4)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_WGreen;
        }

        AudioSource.PlayClipAtPoint(RightButtonAudio, Camera.main.transform.position);
        StartCoroutine(TimeOut());
    }

    public void WrongA()
    {
        bCanPress = false;
        if (LetterChoice == 1)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_ARed;
        }

        if (LetterChoice == 2)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_DRed;
        }

        if (LetterChoice == 3)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_SRed;
        }

        if (LetterChoice == 4)
        {
            UIImage.GetComponent<Image>().sprite = ButtonLogo_WRed;
        }

        AudioSource.PlayClipAtPoint(WrongButtonAudio, Camera.main.transform.position);
        StartCoroutine(TimeOut());
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(3);

        ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(3, 3, 0);
        Check = 0;
        bCanPress = true;
        Timer = SetTimer;
    }
}
