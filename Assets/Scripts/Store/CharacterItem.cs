using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Item/Character Item")]
[System.Serializable]
public class CharacterItem : StoreItem
{
    private Sprite characterSprite;

    public Sprite CharacterSprite
    {
        get
        {
            SetExpressionType(Expression);
            return characterSprite;

        }
    }
    
    [System.Serializable]
    public class ExpressionSprite
    {
        public Sprite normal;
        public Sprite smile;
        public Sprite frown;
        public Sprite laugh;
    }

    public ExpressionSprite expressionSprite;

    public Expressions Expression { get; set; }

    public void SetExpressionType(Expressions newExpression)
    {
        Expression = newExpression;
        switch (Expression)
        {
            case Expressions.Normal:
                characterSprite = expressionSprite.normal;
                break;
            case Expressions.Smile:
                characterSprite = expressionSprite.smile;
                break;
            case Expressions.Frown:
                characterSprite = expressionSprite.frown;
                break;
            case Expressions.Laugh:
                characterSprite = expressionSprite.laugh;
                break;
            default:
                break;
        }
    }
}

public enum Expressions
{
    Normal,
    Smile,
    Frown,
    Laugh
}
