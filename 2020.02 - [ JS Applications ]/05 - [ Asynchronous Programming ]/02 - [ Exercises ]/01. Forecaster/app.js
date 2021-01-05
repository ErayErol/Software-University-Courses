import { weather } from "./fetch.js";

const elements = {
    $location: () => document.getElementById('location'),
    $submit: () => document.getElementById('submit'),
    $todayForecast: () => document.getElementById('current'),
    $upcomingForecasts: () => document.getElementById('upcoming'),
    $forecast: () => document.getElementById('forecast'),
};

const weatherSymbols = {
    'Sunny': '☀',
    'Partly sunny': '⛅',
    'Overcast': '☁',
    'Rain': '☂',
    'Degrees': '°',
};

function attachEvents() {
    elements.$submit().addEventListener('click', getWeatherInfo);

    function getWeatherInfo() {
        const location = elements.$location().value;
        weather()
            .locations()
            .then(cleanerCurrentConditions())
            .then(getTodayAndUpcomingWeather())
            .then(([today, upcoming]) => generateWeatherInfo(today, upcoming))
            .catch((err) => errorMessage(err.message));

        function getTodayAndUpcomingWeather() {
            return (locations) => {
                const currentLocation = locations.find((o) => o.name === location);
                if (!currentLocation) {
                    throw new Error('Incorrect name');
                }
                return Promise.all([
                    weather().today(currentLocation.code),
                    weather().upcoming(currentLocation.code),
                ]);
            };
        }
    }

    function generateWeatherInfo(today, upcoming) {
        elements.$forecast().style.display = 'block';
        generateTodayWeatherInfo(today.forecast, today.name);
        generateUpcomingWeatherInfo(upcoming.forecast);
    }

    function generateTodayWeatherInfo(today, name) {
        const { condition, low, high } = today;
        const forecastsDiv = createHTMLElement('div', 'forecasts');
        const conditionSpan = createHTMLElement('span', 'condition');
        const conditionSymbol = weatherSymbols[condition];
        const conditionSymbolSpan = createHTMLElement('span', 'condition symbol', conditionSymbol);
        const nameSpan = createHTMLElement('span', 'forecast-data', name);
        const degreeLow = `${low}${weatherSymbols['Degrees']}`;
        const degreeHigh = `${high}${weatherSymbols['Degrees']}`;
        const degree = `${degreeLow}/${degreeHigh}`;
        const degreesSpan = createHTMLElement('span', 'forecast-data', degree);
        const conditionNameSpan = createHTMLElement('span', 'forecast-data', condition);
        conditionSpan.append(nameSpan, degreesSpan, conditionNameSpan);
        forecastsDiv.append(conditionSymbolSpan, conditionSpan);
        elements.$todayForecast().append(forecastsDiv);
    }

    function generateUpcomingWeatherInfo(upcoming) {
        const forecastInfoDiv = createHTMLElement('div', 'forecast-info');
        upcoming.forEach((day) => addingDays(day));
        elements.$upcomingForecasts().append(forecastInfoDiv);

        function addingDays(day) {
            const { condition, low, high } = day;
            const upcomingSpan = createHTMLElement('span', 'upcoming');
            const conditionSymbol = weatherSymbols[condition];
            const symbolSpan = createHTMLElement('span', 'symbol', conditionSymbol);
            const degreeLow = `${low}${weatherSymbols['Degrees']}`;
            const degreeHigh = `${high}${weatherSymbols['Degrees']}`;
            const degree = `${degreeLow}/${degreeHigh}`;
            const degreesSpan = createHTMLElement('span', 'forecast-data', degree);
            const conditionNameSpan = createHTMLElement('span', 'forecast-data', condition);
            upcomingSpan.append(symbolSpan, degreesSpan, conditionNameSpan);
            forecastInfoDiv.append(upcomingSpan);
        }
    }

    function createHTMLElement(tagName, className, textContent) {
        const element = document.createElement(tagName);
        element.className = className;
        element.textContent = textContent;
        return element;
    }

    function cleanerCurrentConditions() {
        elements.$location().value = '';
        if (elements.$forecast().children.length === 3) {
            elements.$forecast().removeChild(elements.$forecast().children[2]);
        }
        if (elements.$todayForecast().children.length > 1) {
            elements.$todayForecast().removeChild(elements.$todayForecast().children[1]);
            elements.$upcomingForecasts().removeChild(elements.$upcomingForecasts().children[1]);
        }
    }

    function errorMessage(err) {
        console.log(err);
        cleanerCurrentConditions();
        alert('Incorrect location name.\nTry again, please!');
    }
}

attachEvents();