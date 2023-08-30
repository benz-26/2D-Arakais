using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTyping : MonoBehaviour
{
    public int normalSpeed; // Decreased value for faster typing
    public int fastSpeed = 10; // Decreased value for faster typing
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] GameObject activeObject;

    [SerializeField]
    string text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, " +
            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, " +
            "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

    private Coroutine dialogCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        activeObject.SetActive(false);

        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(0.1f);
        dialogCoroutine = StartCoroutine(TypeDialog(text));
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";

        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            Debug.Log("ats");
            yield return new WaitForSeconds(1f / normalSpeed);
            Debug.Log(letter);
        }
        // Word reaches the last word
        activeObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonSkip()
    {
        StopAllCoroutines();
        dialogText.text = text;

    }

    // Called when the space button is pressed
    public void OnSpaceButtonPressed()
    {
        if (dialogCoroutine != null)
        {
            StopCoroutine(dialogCoroutine);
        }

        dialogCoroutine = StartCoroutine(TypeDialog(text));
    }
}
