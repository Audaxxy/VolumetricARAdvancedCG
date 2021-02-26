using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArtistUI
{
    [CreateAssetMenu(fileName = "Artist List", menuName = "ScriptableObjects/Artist UI/Artist List")]
    public class ArtistList : ScriptableObject
    {
        public List<SingleArtist> allArtistPrefabs;
    }
}