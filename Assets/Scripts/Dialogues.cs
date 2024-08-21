using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogues : MonoBehaviour
{
    public Text textBox;

    private IEnumerator coroutineGuard1;
    private IEnumerator coroutineArissa1;
    private IEnumerator coroutineDecision;
    private IEnumerator coroutineGuard2;

    private bool kill;
    private bool isDecided;
    private bool talkedToArissa;
    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();

        coroutineGuard1 = dialogGuard1();
        coroutineArissa1 = dialogArissa1();
        coroutineDecision = decision();
        coroutineGuard2 = dialogGuard2();

        textBox.text = "Chegue perto dos NPC's e aperte 'Q' para conversar";

        isDecided = false;
        talkedToArissa = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GanfaulMoviment.FindObjectOfType<GanfaulMoviment>().triggerGuard == true)
        {
            if (isDecided == false)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                    StartCoroutine(coroutineGuard1);
            }
        }
            
        if (GanfaulMoviment.FindObjectOfType<GanfaulMoviment>().triggerGuard == false)
        {
            StopCoroutine(coroutineGuard1);
            coroutineGuard1 = dialogGuard1();
        }

        if (GanfaulMoviment.FindObjectOfType<GanfaulMoviment>().triggerArissa == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                StartCoroutine(coroutineArissa1);
        }

        if (GanfaulMoviment.FindObjectOfType<GanfaulMoviment>().triggerArissa == false)
        {
            StopCoroutine(coroutineArissa1);
            coroutineArissa1 = dialogArissa1();
        }

        if (GanfaulMoviment.FindObjectOfType<GanfaulMoviment>().triggerDecision == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                StartCoroutine(coroutineDecision);
        }

        if (GanfaulMoviment.FindObjectOfType<GanfaulMoviment>().triggerDecision == false)
        {
            StopCoroutine(coroutineDecision);
            coroutineDecision = decision();
        }

        if (GanfaulMoviment.FindObjectOfType<GanfaulMoviment>().triggerGuard == true)
        {
            if (isDecided == true)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                    StartCoroutine(coroutineGuard2);
            }
        }
    }

    IEnumerator dialogGuard1()
    {
        textBox.text = "Olá viajante!! Como está?";
        yield return new WaitForSeconds(3);
        textBox.text = "Sei que você acabou de chegar, e que eu não deveria pedir ajuda à estranhos, mas...";
        yield return new WaitForSeconds(4);
        textBox.text = "Será que você poderia pegar uma coisa na casa do meu com meu irmão?";
        yield return new WaitForSeconds(4);
        textBox.text = "É um anel muito importante pra mim, que ele roubou! \n" +
            "S - Aceitar missão. \n" +
            "W - Negar a missão.";

        var option = 0;

        while (option==0)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.S))
            {
                option = 1;
                textBox.text = "Muito obrigado! Irei te recompensar assim que voltar com o anel.";
                yield return new WaitForSeconds(3);
                textBox.text = "";
                StopCoroutine(coroutineGuard1);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                option = 2;
                textBox.text = "Ah ok então, sabia que não podia contar com estranhos...";
                yield return new WaitForSeconds(3);
                textBox.text = "";
                StopCoroutine(coroutineGuard1);
            }
        }
    }

    IEnumerator dialogArissa1()
    {
        talkedToArissa = true;
        textBox.text = "Olá estranho, o que busca nesse lugar hein?...";
        yield return new WaitForSeconds(3);
        textBox.text = "Bem, não importa. Você me parece ser a pessoa perfeita para executar o meu plano...";
        yield return new WaitForSeconds(5);
        textBox.text = "Sabe aquele guarda na frente da porta? Pegue uma espada na casa do irmão dele e o mate!!";
        yield return new WaitForSeconds(5);
        textBox.text = "É apenas uma vingança pelo que ele fez com minha família, o que achar da proposta?";
        yield return new WaitForSeconds(5);
        textBox.text = "Irei te recompensar muito bem assim que terminar o trabalho... \n" +
            "S - Aceitar missão. \n" +
            "W - Negar a missão.";

        var option = 0;

        while (option == 0)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.S))
            {
                option = 1;
                textBox.text = "Ótimo! Aquele miserável terá o que ele merece!!!";
                yield return new WaitForSeconds(3);
                textBox.text = "";
                StopCoroutine(coroutineArissa1);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                option = 2;
                textBox.text = "Meh, você não conseguiria fazer um trabalho difícil desses mesmo. Agora some daqui!";
                yield return new WaitForSeconds(3);
                textBox.text = "";
                StopCoroutine(coroutineArissa1);
            }
        }
    }

    IEnumerator decision()
    {
        textBox.text = "Você escontra um anel e uma espada... \n" +
            "S - Pegar o anel. \n" +
            "W - Pegar a espada.";

        var option = 0;

        while (option == 0)
        {
            yield return null;

            if (Input.GetKeyDown(KeyCode.S))
            {
                kill = false;
                isDecided = true;
                option = 1;
                textBox.text = "Você escolheu pegar o anel.";
                yield return new WaitForSeconds(2);
                textBox.text = "";
                StopCoroutine(coroutineDecision);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                kill = true;
                isDecided = true;
                option = 2;
                textBox.text = "Você escolheu pegar a espada.";
                yield return new WaitForSeconds(3);
                textBox.text = "";
                StopCoroutine(coroutineDecision);
            }
        }
    }

    IEnumerator dialogGuard2()
    {
        if (kill == false)
        {
            textBox.text = "Ah, muito obrigado mesmo!!! Você não sabe o quanto eu estou grato!";
            yield return new WaitForSeconds(3);
            textBox.text = "Tome aqui esta jóia como presente!";
            yield return new WaitForSeconds(3);
            textBox.text = "VOCÊ ESCOLHEU NÃO SE CORROMPER";
            StopCoroutine(coroutineGuard2);
            Time.timeScale = 0;
        }

        if (talkedToArissa == false)
            if (kill == true)
            {
                textBox.text = "Ei, não foi isso que eu te pedi...";
                yield return new WaitForSeconds(3);
                textBox.text = "Espere! O que você está fazendo??!! NÃÃÃÃÃO!!!";
                yield return new WaitForSeconds(3);
                textBox.text = "VOCÊ ESCOLHEU SE CORROMPER";
                StopCoroutine(coroutineGuard2);
                Time.timeScale = 0;
            }

        if (talkedToArissa == true)
            if (kill == true)
            {
                textBox.text = "Ei, o que é isso, estranho? Por que está me apontando uma espada??!";
                yield return new WaitForSeconds(4);
                textBox.text = "Espere! O que você está fazendo??!! NÃÃÃÃÃO!!!";
                yield return new WaitForSeconds(3);
                textBox.text = "VOCÊ ESCOLHEU SE CORROMPER";
                StopCoroutine(coroutineGuard2);
                Time.timeScale = 0;
            }
    }
}
