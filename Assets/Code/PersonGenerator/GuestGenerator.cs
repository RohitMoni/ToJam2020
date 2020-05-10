﻿using System.Collections;
using System.Collections.Generic;
using Seating;
using UnityEngine;
using UnityEngine.UI;

namespace _2020Vision
{
    //Class for generating a random guest to have, including a name and portrait.

    //Should be placed on an object, likely in the main menu, so that the singleton is set. It's late and I forget how to do singleton stuff in unity correctly.
    //I also think this may or may not be entirely what people want, so idk. Look at it and tell me if it's right when I get back in the morning.
    public class GuestGenerator : MonoBehaviour
    {
        private static GuestGenerator singleton = null;

        public GameObject GuestPrefab;

        public List<Sprite> Heads;
        public List<Sprite> Hairs_MascBottom;
        public List<Sprite> Hairs_MascOval;
        public List<Sprite> Hairs_MascRound;
        public List<Sprite> Hairs_FemmeRound;
        public List<Sprite> Eyes;
        public List<Sprite> Mouths;

        public static GuestGenerator Singleton
        {
            get
            {
                if (singleton == null)
                {
                    Debug.LogError("An guest generator was not found in the main play scene. Please place one so that the singleton for the guest generator is instantiated.");
                }
                return singleton;
            }

            private set
            {
                singleton = value;
            }
        }

        private void Awake()
        {
            if (singleton != null)
            {
                Destroy(this);
            }

            DontDestroyOnLoad(this);
            Singleton = this;
        }

        private GuestGenerator()
        {
        }

        private Sprite GetRandomHead()
        {
            return Heads[Random.Range(0, Heads.Count - 1)];
        }

        private Sprite GetMascBottomHair()
        {
            return Hairs_MascBottom[Random.Range(0, Hairs_MascBottom.Count - 1)];
        }

        private Sprite GetOvalMascHair()
        {
            return Hairs_MascOval[Random.Range(0, Hairs_MascOval.Count - 1)];
        }

        private Sprite GetRoundMascHair()
        {
            return Hairs_MascRound[Random.Range(0, Hairs_MascRound.Count - 1)];
        }

        private Sprite GetRoundFemmeHair()
        {
            return Hairs_FemmeRound[Random.Range(0, Hairs_FemmeRound.Count - 1)];
        }

        private Sprite GetRandomEyes()
        {
            return Eyes[Random.Range(0, Eyes.Count - 1)];
        }

        private Sprite GetRandomMouths()
        {
            return Mouths[Random.Range(0, Mouths.Count - 1)];
        }

        public GameObject CreateGuest()
        {
            GameObject newGuestObject = Instantiate(GuestPrefab);

            Guest newGuest = newGuestObject.GetComponent<Guest>();
            
            //Head shape
            Sprite newHead = GetRandomHead();
            if (newHead == null)
            {
                int i = 0;
                i++;
            }
            int headIndex = Heads.IndexOf(newHead);
            newGuest.SetPortrait(newHead, headIndex);

            //Hair
            if (newHead.name.ToLower().Contains("bottom"))
            {
                Sprite newHair = GetMascBottomHair();
            }
            else if (newHead.name.ToLower().Contains("oval"))
            {
                Sprite newHair = GetOvalMascHair();
            }
            else if (newHead.name.ToLower().Contains("round"))
            {
                if (Random.value > 0.5)
                {
                    Sprite newHair = GetRoundFemmeHair();
                }
                else
                {
                    Sprite newHair = GetRoundMascHair();
                }
            }

            //Mouth shape
            newGuest.SetMouth(GetRandomMouths());

            //Eye shape
            newGuest.SetEyes(GetRandomEyes());

            return newGuestObject;
        }
    }
}