import requests
from requests.exceptions import HTTPError
from dotenv import load_dotenv
import os

load_dotenv()

API_KEY = os.environ["API_KEY"]


def get_current_temperature(city: str) -> float:
    base_url = "https://api.openweathermap.org/data/2.5/weather"
    
    params = {
        'q': city,
        "units": "metric",
        'appid': API_KEY 
    }
    try:
        response = requests.get(base_url, params=params)
        response.raise_for_status()
    except HTTPError as e:
        if response.status_code == 404:
            raise ValueError(f"Wrong city!\n\n{e}, ") from e
        raise HTTPError(f"Wrong request!\n\n{e}, ")
        
    data = response.json()
    temperature = data['main']['temp']
    return temperature

if __name__ == "__main__":
    city = input("Podaj miasto, dla ktorego chcesz sprawdzi temperature: ")
    
    
    current_temp = get_current_temperature(city=city)

    print(f"Temperatura w wybranym miescie {city} wynosi: {current_temp}°C.")