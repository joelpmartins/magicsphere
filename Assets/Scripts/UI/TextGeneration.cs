using System;
using UnityEngine;

public class TextGeneration : MonoBehaviour
{
    private enum CharacterType
    {
        Letter,
        Number,
        Special
    }

    private enum SpecialCharacter
    {
        Exclamation = '!',
        Percentage = '%',
        Ampersand = '&',
        Apostrophe = '\'',
        Colon = ',',
        Dot = '.',
        Question = '?',
        Bracket = '[',
    }

    public static TextGeneration instance { get; private set; }
    [SerializeField] private GameObject[] _letterPrefabs;
    [SerializeField] private GameObject[] _numberPrefabs;
    [SerializeField] private GameObject[] _specialPrefabs;
    private char[] _specEnumArr;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        _specEnumArr = GetSpecEnumArr();
    }

    public void Print(Transform container, string text)
    {
        int i;
        Vector3 pos = container.position;
        char[] charArr = text.ToCharArray();

        EmptyContainer(container);

        for (i = 0; i < charArr.Length; ++i)
        {
            pos.x += 3f;
            if (charArr[i] == ' ')
                continue;
            InstantiateCharacter(container, pos, charArr[i]);
        }
    }

    private char[] GetSpecEnumArr()
    {
        int i;
        Array enumArr = Enum.GetValues(typeof(SpecialCharacter));
        char[] charArr = new char[enumArr.Length];
        for (i = 0; i < charArr.Length; ++i)
            charArr[i] = Convert.ToChar(enumArr.GetValue(i));
        return charArr;
    }

    private void EmptyContainer(Transform container)
    {
        int i;
        for (i = 0; i < container.childCount; ++i)
            Destroy(container.GetChild(i).gameObject);
    }

    private void InstantiateCharacter(Transform container, Vector3 pos, char c)
    {
        CharacterType type = GetCharacterType(c);
        GameObject prefab = GetCharacterPrefab(type, c);
        GameObject go;

        if (prefab == null)
            return;

        go = Instantiate(prefab, pos, Quaternion.Euler(0f, 180f, 0f));
        go.transform.localScale = new Vector3(6f, 6f, 6f);
        go.layer = container.gameObject.layer;
        go.transform.parent = container;
    }

    private CharacterType GetCharacterType(char c)
    {
        if (Char.IsLetter(c))
            return CharacterType.Letter;
        else if (Char.IsNumber(c))
            return CharacterType.Number;
        else
            return CharacterType.Special;
    }

    private GameObject GetCharacterPrefab(CharacterType type, char c)
    {
        int i;

        if (type == CharacterType.Letter)
            return _letterPrefabs[char.ToUpper(c) - 'A'];
        else if (type == CharacterType.Number)
            return _numberPrefabs[c - '0'];
        else
        {
            for (i = 0; i < _specEnumArr.Length; ++i)
            {
                if (c == _specEnumArr[i])
                    return _specialPrefabs[i];
            }
        }
        return null;
    }
}
