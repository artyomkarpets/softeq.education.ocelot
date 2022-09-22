var userProfile = {
    "Type": "userProfile",//uniq for now
    "Version": 1,
    "CreatedDateTime": new Date(),
    "Period:":"initial", //initial, dayly, monthly, weekly, last - get from questionnaire service
    "Title": [{
        "Local": "en-en",
        "Text": "User Profile"
    },
    {
        "Local": "ru-ru",
        "Text": "Профиль пользователя"
    }
    ],
    "Description": [],//If necessary additional description
    "Questions": [
        {
            "Name": "weight",
            "QuestionType": "Number",//freeText, number, singleSelect,multiSelect,readonly
            "DataType": "int",//int, string
            "DefaultValue": "0",
            "ContentUrl:": null,//relative url to cms
            "ContentType:": "none",//video, picture, page from CMS
            "Title": [{
                "Local": "en-en",
                "Text": "Weight:"
            },
            {
                "Local": "ru-ru",
                "Text": "Масса"
            }
            ],
            "Description": [{
                "Local": "en-en",
                "Text": "Please enter your weight"
            },
            {
                "Local": "ru-ru",
                "Text": "Введите Ваш вес"
            }
            ],
            "Validations": [{
                "Rule": "minValue",
                "Value": "0"
            }]
        },
        {
            "Name": "height",
            "QuestionType": "Number",
            "DataType": "int",
            "DefaultValue": "0",
            "Title": [{
                "Local": "en-en",
                "Text": "Weight:"
            },
            {
                "Local": "ru-ru",
                "Text": "Масса"
            }
            ],
            "Description": [{
                "Local": "en-en",
                "Text": "Please enter your height"
            },
            {
                "Local": "ru-ru",
                "Text": "Введите Ваш рост"
            }
            ],
            "Validations": [{
                "Rule": "minValue",//maxValue,Requared
                "Value": "0"
            }]
        },
        {
            "Name": "devices",
            "QuestionType": "readonly",
            "DataType": "string",
            "DefaultValue": "0",
            "Title": [{
                "Local": "en-en",
                "Text": "Devices:"
            },
            {
                "Local": "ru-ru",
                "Text": "Устройства:"
            }
            ],
            "Description": [
            ],
            "Validations": []
        },
    ]
}