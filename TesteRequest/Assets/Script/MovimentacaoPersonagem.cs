using Assets;
using Assets.Model;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class MovimentacaoPersonagem : MonoBehaviour
{
    [Header("Configuracao")]
    [SerializeField]
    private bool _local;
    [SerializeField]
    private float _velocidade;
    [SerializeField]
    private float _distanciaParar;
    [SerializeField]
    private CapturaDeInputs _capturaDeInputs;
    public MovimentacaoPlayer playerLocal;

    public int contador;

    private Rigidbody2D _rb2D;
    private MovimentacaoPlayer _player;

    private void Start()
    {
        if (_local)
        {
            StartCoroutine(CriarPlayer());
            StartCoroutine(AtualizarPosicao());
        }
        else
        {
            StartCoroutine(BuscarPosicao());
        }

        _rb2D = this.GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        if (_local)
            DeletarPlayer();
    }

    private void FixedUpdate()
    {
        if (_local)
        {
            this.Movimentacao(_capturaDeInputs.Vertical, _capturaDeInputs.Horizontal);
        }
        else
        {
            this.CalculaVelocidade();
        }
    }

    private void CalculaVelocidade()
    {
        if (_player is null) return;

        float inpHori = 0;

        float inpVert = 0;

        Vector2 posicaoAtual = transform.position;
        Vector2 posicaoFutura = new Vector2(_player.valorX, _player.valorY);

        float distancia = Vector2.Distance(posicaoAtual, posicaoFutura);

        //if (distancia <= _distanciaParar)
        //{
        //    Movimentacao(0, 0);
        //    return;
        //}

        //if (posicaoAtual.x > posicaoFutura.x)
        //    inpHori = -1;
        //if (posicaoAtual.x < posicaoFutura.x)
        //    inpHori = 1;

        //if (posicaoAtual.y > posicaoFutura.y)
        //    inpVert = -1;
        //if (posicaoAtual.y < posicaoFutura.y)
        //    inpVert = 1;

        //if(_movemento != null)
        //{
        //    StopCoroutine(_movemento);
        //    _movemento = null;
        //}

        //if (_movemento is null)
        //    _movemento = StartCoroutine(MoveToExactPosition(posicaoFutura, _distanciaParar));


        transform.position = posicaoFutura;

        Movimentacao(inpVert, inpHori);
    }

    private void Movimentacao(float inpVertical, float inpHorizontal)
    {
        Vector2 direcao = new Vector2(_rb2D.velocity.x + (_velocidade * inpHorizontal), _rb2D.velocity.y + (_velocidade * inpVertical));

        if (inpVertical == 0)
            direcao.y = 0f;

        if (inpHorizontal == 0)
            direcao.x = 0f;

        _rb2D.velocity = direcao;


    }

    IEnumerator BuscarPosicao()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:52381/api/Movimentacao/" + playerLocal.id))
        {
            contador++;
            yield return request.SendWebRequest();

            if (request.isNetworkError)
                Debug.LogError(request.error);
            else
                _player = JsonUtility.FromJson<MovimentacaoPlayer>(request.downloadHandler.text);

            StartCoroutine(BuscarPosicao());
        }
    }

    IEnumerator CriarPlayer()
    {
        contador++;
        string json = JsonUtility.ToJson(playerLocal);

        UnityWebRequest request = new UnityWebRequest("http://localhost:52381/api/Movimentacao", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
    }


    IEnumerator AtualizarPosicao()
    {
        contador++;
        playerLocal.valorX = this.transform.position.x;
        playerLocal.valorY = this.transform.position.y;
        string json = JsonUtility.ToJson(playerLocal);

        UnityWebRequest request = new UnityWebRequest("http://localhost:52381/api/Movimentacao/", "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        StartCoroutine(AtualizarPosicao());
    }

    private void DeletarPlayer()
    {
        string json = JsonUtility.ToJson(playerLocal);

        UnityWebRequest request = new UnityWebRequest("http://localhost:52381/api/Movimentacao", "DELETE");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest();
    }
}
