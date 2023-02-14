using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelCustomizer : MonoBehaviour
{
    public GameObject[] Figures;
	public GameObject Background;
	public GameObject[] Balls;

	public Sprite[] RingSprites;
    public Sprite[] SquareSprites;
    public Sprite[] TriangleSprites;
	public Sprite[] BackgroundSprites;
	public Sprite[] BallSprites;

    void Start()
    {
        SetBackground();
        SetBalls();

        for(int i = 0; i < Figures.Length; i ++)
        {
            if(Figures[i].CompareTag("Ring"))
            {
                SetRing(Figures[i]);
            }
            else if(Figures[i].CompareTag("Square"))
            {
                SetSquare(Figures[i]);
            }
            else if(Figures[i].CompareTag("Triangle"))
            {
                SetTriangle(Figures[i]);
            }
        }
    }

    void SetRing(GameObject Ring)
    {
        int sectionSpriteNum = ItemsManagement.ChosenRing * 4;

        GameObject CurrCouple;
        GameObject CurrSection;

        for(int i = 0; i < Ring.transform.childCount; i++)
        {
            CurrCouple = Ring.transform.GetChild(i).gameObject;

            for(int j = 0; j < CurrCouple.transform.childCount; j++)
            {
                CurrSection = CurrCouple.transform.GetChild(j).gameObject;

                CurrSection.GetComponent<SpriteRenderer>().sprite = RingSprites[sectionSpriteNum];
                CurrSection.GetComponent<SectionControlNeighbours>().SectionStart = RingSprites[sectionSpriteNum];
                CurrSection.GetComponent<SectionControlNeighbours>().SectionLeftCorner = RingSprites[sectionSpriteNum+1];
                CurrSection.GetComponent<SectionControlNeighbours>().SectionRightCorner = RingSprites[sectionSpriteNum+2];
                CurrSection.GetComponent<SectionControlNeighbours>().SectionSingle = RingSprites[sectionSpriteNum+3];
            }
        }
    }

    void SetSquare(GameObject Square)
    {
        int sectionSpriteNum = ItemsManagement.ChosenRing * 8;

        GameObject CurrSide;
        GameObject CurrSection;

        for(int i = 0; i < Square.transform.childCount; i++)
        {
            CurrSide = Square.transform.GetChild(i).gameObject;

            for(int j = 0; j < CurrSide.transform.childCount; j++)
            {
                CurrSection = CurrSide.transform.GetChild(j).gameObject;

                if(CurrSection.CompareTag("Section"))
                {                    
                    CurrSection.GetComponent<SpriteRenderer>().sprite = SquareSprites[sectionSpriteNum];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionStart = SquareSprites[sectionSpriteNum];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionLeftCorner = SquareSprites[sectionSpriteNum+1];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionRightCorner = SquareSprites[sectionSpriteNum+2];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionSingle = SquareSprites[sectionSpriteNum+3];
                }
                else if(CurrSection.CompareTag("Corner"))
                {
                    CurrSection.GetComponent<SpriteRenderer>().sprite = SquareSprites[sectionSpriteNum+4];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionStart = SquareSprites[sectionSpriteNum+4];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionLeftCorner = SquareSprites[sectionSpriteNum+5];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionRightCorner = SquareSprites[sectionSpriteNum+6];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionSingle = SquareSprites[sectionSpriteNum+7];
                }
            }
        }
    }

    void SetTriangle(GameObject Triangle)
    {
        int sectionSpriteNum = ItemsManagement.ChosenRing * 8;

        GameObject CurrSide;
        GameObject CurrSection;

        for(int i = 0; i < Triangle.transform.childCount; i++)
        {
            CurrSide = Triangle.transform.GetChild(i).gameObject;

            for(int j = 0; j < CurrSide.transform.childCount; j++)
            {
                CurrSection = CurrSide.transform.GetChild(j).gameObject;

                if(CurrSection.CompareTag("Section"))
                {                    
                    CurrSection.GetComponent<SpriteRenderer>().sprite = TriangleSprites[sectionSpriteNum];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionStart = TriangleSprites[sectionSpriteNum];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionLeftCorner = TriangleSprites[sectionSpriteNum+1];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionRightCorner = TriangleSprites[sectionSpriteNum+2];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionSingle = TriangleSprites[sectionSpriteNum+3];
                }
                else if(CurrSection.CompareTag("CornerR"))
                {
                    CurrSection.GetComponent<SpriteRenderer>().sprite = TriangleSprites[sectionSpriteNum+4];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionStart = TriangleSprites[sectionSpriteNum+4];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionLeftCorner = TriangleSprites[sectionSpriteNum+5];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionRightCorner = TriangleSprites[sectionSpriteNum+2];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionSingle = TriangleSprites[sectionSpriteNum+3];
                }
                else if(CurrSection.CompareTag("CornerL"))
                {
                    CurrSection.GetComponent<SpriteRenderer>().sprite = TriangleSprites[sectionSpriteNum+6];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionStart = TriangleSprites[sectionSpriteNum+6];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionLeftCorner = TriangleSprites[sectionSpriteNum+1];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionRightCorner = TriangleSprites[sectionSpriteNum+7];
                    CurrSection.GetComponent<SectionControlNeighbours>().SectionSingle = TriangleSprites[sectionSpriteNum+3];
                }
            }
        }        
    }

    void SetBackground()
    {
        Background.GetComponent<Image>().sprite = BackgroundSprites[ItemsManagement.ChosenBackground];
    }

    void SetBalls()
    {        
        for(int i = 0; i < Balls.Length; i++)
        {
            Balls[i].GetComponent<SpriteRenderer>().sprite = BallSprites[ItemsManagement.ChosenBall];
        }
    }
}
