using UnityEngine;


    /// <summary>
    /// A Singleton Defining Class that is attached to any object and makes
    /// it behave and work as a single instance that is not destroyed nor
    /// duplicated.
    /// Note: This Singleton does not live through the scenes.
    /// </summary>
    /// <typeparam name="T">Class Type of Object</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // A Single instance to reference the singlton
        private static T instance;

        /// <summary>
        /// A Setter & Getter for the instance to be accessible by
        /// all other classes.
        /// </summary>
        public static T Instance
        {
            get
            {
                // Check if the instance is null
                if (instance)
                {
                    // First try to find the object already in the scene
                    instance = GameObject.FindObjectOfType<T>();

                    if (instance == null)
                    {
                        // Couldn't find the singleton in the scene, so make it.
                        GameObject singleton = new GameObject(typeof(T).Name);
                        instance = singleton.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// The Awake method runs first thing in the morning xD,
        /// when scene is loaded if no instance is found then create it
        /// and don't destroy it ever, but if a duplicate was found then
        /// destroy it.
        /// </summary>
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }