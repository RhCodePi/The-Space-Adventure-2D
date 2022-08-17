using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rhcodepi
{
    public class Planets : MonoBehaviour
    {
        List<GameObject> planets = new List<GameObject>();
        List<GameObject> usingPlanet = new List<GameObject>();
        void Awake()
        {
            Object[] sprites = Resources.LoadAll("Planets");
            foreach (var item in sprites)
            {
                if (item.GetType() == typeof(Sprite))
                {
                    GameObject planet = new GameObject();
                    planet.AddComponent<SpriteRenderer>();
                    planet.GetComponent<SpriteRenderer>().sprite = (Sprite)item;
                    Color planetAlfa = planet.GetComponent<SpriteRenderer>().color;
                    planetAlfa.a = 0.75f;
                    planet.GetComponent<SpriteRenderer>().color = planetAlfa;
                    planet.name = item.name;
                    planet.GetComponent<SpriteRenderer>().sortingLayerName = "Planet";
                    planet.transform.parent = transform;
                    Vector2 pos = new Vector2(-10, planet.transform.position.y);
                    planet.transform.position = pos;
                    planets.Add(planet);
                }
            }
        }

        public void SetPlanet(float refY)
        {
            float width = PlatformPath.instance.Width;
            float height = PlatformPath.instance.Height;

            // 1.CordinatePoint
            float xCordinate_1 = Random.Range(0.0f, width);
            float yCordinate_1 = Random.Range(refY, refY + height);
            GameObject planet_1 = GeneratePlanet();
            planet_1.transform.position = new Vector2(xCordinate_1, yCordinate_1);

            // 2.CordinatePoint
            float xCordinate_2 = Random.Range(-width, 0.0f);
            float yCordinate_2 = Random.Range(refY, refY + height);
            GameObject planet_2 = GeneratePlanet();
            planet_2.transform.position = new Vector2(xCordinate_2, yCordinate_2);

            // 3.CordinatePoint
            float xCordinate_3 = Random.Range(-width, 0.0f);
            float yCordinate_3 = Random.Range(refY - height, refY);
            GameObject planet_3 = GeneratePlanet();
            planet_3.transform.position = new Vector2(xCordinate_3, yCordinate_3);

            // 4.CordinatePoint
            float xCordinate_4 = Random.Range(0.0f, width);
            float yCordinate_4 = Random.Range(refY - height, refY);
            GameObject planet_4 = GeneratePlanet();
            planet_4.transform.position = new Vector2(xCordinate_4, yCordinate_4);

        }

        GameObject GeneratePlanet()
        {
            GameObject randomPlanet = null;
            int random = 0;
            if (planets.Count > 0)
            {
                if (planets.Count == 1)
                {
                    random = 0;
                }
                else
                {
                    random = Random.Range(0, planets.Count - 1);
                }
                randomPlanet = planets[random];

                usingPlanet.Add(randomPlanet);
                planets.Remove(randomPlanet);
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    planets.Add(usingPlanet[i]);
                }
                usingPlanet.RemoveRange(0, 8);

                random = Random.Range(0, planets.Count - 1);
                randomPlanet = planets[random];

                usingPlanet.Add(randomPlanet);
                planets.Remove(randomPlanet);
            }
            return randomPlanet;
        }

    }
}

