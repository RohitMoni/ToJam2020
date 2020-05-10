using System.Collections;
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

        public List<Sprite> Heads;
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

        private GuestGenerator()
        {
            if (Singleton != null)
            {
                Destroy(this);
            }

            DontDestroyOnLoad(this);
            Singleton = this;
        }

        private Sprite GetRandomHead()
        {
            return Heads[Random.Range(0, Heads.Count - 1)];
        }

        private Sprite GetRandomEyes()
        {
            return Eyes[Random.Range(0, Heads.Count - 1)];
        }

        private Sprite GetRandomMouths()
        {
            return Mouths[Random.Range(0, Heads.Count - 1)];
        }

        public Guest CreatePerson()
        {
            Guest newGuest = new Guest();

            Sprite newHead = GetRandomHead();
            int headIndex = Heads.IndexOf(newHead);
            newGuest.SetPortrait(newHead, headIndex);

            newGuest.SetMouth(GetRandomMouths());
            newGuest.SetEyes(GetRandomEyes());

            return newGuest;
        }
    }
}