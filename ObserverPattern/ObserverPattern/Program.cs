using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData);
            weatherData.SetMeasurement(20, 30, 40);

            Console.ReadKey();
        }
    }

    public interface Observer
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface DisplayElement
    {
        void Display();
    }

    public interface Subject
    {
        void RegisterObserver(Observer observer);

        void RemoveObserver(Observer observer);

        void NotifyObservers();
    }

    public class WeatherData : Subject
    {
        public List<Observer> observers = new List<Observer>();
        private float temp;
        private float humidity;
        private float pressure;

        public void RegisterObserver(Observer observer)
        {
            if (observers.Contains(observer))
            {
                return;
            }
            observers.Add(observer);
        }

        public void RemoveObserver(Observer observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            observers.ForEach((observer) =>
            {
                observer.Update(temp, humidity, pressure);
            });
        }

        public void MeasurementChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurement(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementChanged();
        }
    }

    public class CurrentConditionDisplay : Observer, DisplayElement
    {
        private float temp;
        private float humidity;
        private float pressure;
        private Subject weatherData;

        public CurrentConditionDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: {0} degree, {1} humidity, {2} pressure", this.temp, this.humidity, this.pressure);
        }
    }
}