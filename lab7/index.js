const mbHelper = require('mountebank-helper');

const currencies = {
    'USD': 73.4419,
    'EUR': 79.7264,
    'GBP': 99.097,   
    'JPY': 0.6510,  
    'CNY': 13.4393, 
    'RUB': 1.0   
};

const availableCurrency = ['USD', 'EUR', 'GBP', 'JPY', 'CNY', 'RUB'];

const imposter = new mbHelper.Imposter({ 'imposterPort': 3000 });

const responseAll = {
    'uri': 'all',
    'verb': 'GET',
    'res': {
        'statusCode': 200,
        'responseHeaders': { 'Content-Type': 'application/json' },
        'responseBody': JSON.stringify(currencies),
    }
};

imposter.addRoute(responseAll);

availableCurrency.forEach(currency => {
    const currenciesCopy = { ...currencies }; 
    const value = currencies[currency]; 

    availableCurrency.forEach(item => {
        currenciesCopy[item] = (currenciesCopy[item] / value).toFixed(4);
    });

    const responseCurrency = {
        'uri': currency,
        'verb': 'GET',
        'res': {
            'statusCode': 200,
            'responseHeaders': { 'Content-Type': 'application/json' },
            'responseBody': JSON.stringify(currenciesCopy),
        }
    };

    imposter.addRoute(responseCurrency);
});

mbHelper.startMbServer(2525)
    .then(() => {
        imposter.postToMountebank()
            .then(() => {
                console.log('Imposter Posted! Go to http://localhost:3000/all');
            });
    });