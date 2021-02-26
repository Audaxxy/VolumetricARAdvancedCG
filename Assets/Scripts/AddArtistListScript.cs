using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ArtistUI
{
    [RequireComponent(typeof(RectTransform))]
    public class AddArtistListScript : MonoBehaviour
    {
        public ArtistList artistList;
        private List<SingleArtist> instantiatedArtists = new List<SingleArtist>();
        private Vector3 offset = Vector3.zero;
        private RectTransform rt;

        private void Awake()
        {
            rt = GetComponent<RectTransform>();
            rt.transform.position = Vector3.zero;

            for (int i = 0; i < artistList.allArtistPrefabs.Count; ++i)
            {
                SingleArtist artist = artistList.allArtistPrefabs[i];

                offset += artist.offset * 0.5f;
                instantiatedArtists.Add(Instantiate(artist, transform));
            }

            Vector2 newOffset = offset * 2.0f;
            rt.sizeDelta += newOffset;

            Vector3 individualOffset = -offset;

            for (int i = 0; i < instantiatedArtists.Count; ++i)
            {
                SingleArtist artist = instantiatedArtists[i];

                individualOffset += artist.offset * 0.5f;
                artist.transform.localPosition = individualOffset;
                individualOffset += artist.offset * 0.5f;
            }
        }
    }
}