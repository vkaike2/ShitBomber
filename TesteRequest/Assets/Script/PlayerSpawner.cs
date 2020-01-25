using Assets.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Script
{
    public class PlayerSpawner : MonoBehaviour
    {
        [Header("PREFABS")]
        [SerializeField]
        private GameObject _playerPrefab;
        public int contador;

        private void Start()
        {
            StartCoroutine(BuscarPosicao());
        }

        IEnumerator BuscarPosicao()
        {
            List<MovimentacaoPersonagem> todoasMovimentacoesPersonagens = GameObject.FindObjectsOfType<MovimentacaoPersonagem>().ToList();

            VariasMovimentacoes playersLogados = null;

            using (UnityWebRequest request = UnityWebRequest.Get("http://localhost:52381/api/Movimentacao/todos"))
            {
                contador++;
                yield return request.SendWebRequest();

                if (request.isNetworkError)
                    Debug.LogError(request.error);
                else
                {
                    playersLogados = JsonUtility.FromJson<VariasMovimentacoes>(request.downloadHandler.text);

                    if (playersLogados.playersList != null)
                    {
                        List<int> idList = todoasMovimentacoesPersonagens.Select(e => e.playerLocal.id).ToList();

                        List<MovimentacaoPlayer> playersParaSpawnar = playersLogados.playersList.Where(e => !idList.Contains(e.id)).ToList();

                        foreach (var player in playersParaSpawnar)
                        {
                            this.SpawnarPlayer(player);
                        }
                    }
                }

                //StartCoroutine(BuscarPosicao());
            }
        }

        private void SpawnarPlayer(MovimentacaoPlayer player)
        {
            GameObject gameObject = Instantiate(_playerPrefab, new Vector3(player.valorX, player.valorY, 0), Quaternion.identity);
            gameObject.GetComponent<MovimentacaoPersonagem>().playerLocal = player;
        }
    }
}
