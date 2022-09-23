var userProfile = {
    "Type": "UserProfile",//uniq for now
    "Version": 1,
    "CreatedDateTime": new Date(),
    "Period:": "initial", //initial, dayly, monthly, weekly, last - get from questionnaire service
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
            "Name": "Weight",
            "QuestionType": "Number",//FreeText, Number, SingleSelect,MultiSelect,Readonly
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
            "Name": "Height",
            "QuestionType": "Number",
            "DataType": "int",
            "DefaultValue": "0",
            "Title": [{
                "Local": "en-en",
                "Text": "Your height:"
            },
            {
                "Local": "ru-ru",
                "Text": "Ваш рост"
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
                "Rule": "MinValue",//MaxValue,Requared
                "Value": "0"
            }]
        },
        {
            "Name": "devices",
            "QuestionType": "Readonly",
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
        {
            "Name": "DoYouSmoke",
            "QuestionType": "SingleSelect",
            "DataType": "string",
            "DefaultValue": null,
            "Title": [{
                "Local": "en-en",
                "Text": "Do you smoke? :"
            },
            {
                "Local": "ru-ru",
                "Text": "Курите ли вы?"
            }
            ],
            "Description": [
            ],
            "Validations": [],
            "Answers": [
                {
                    "Name": "Yes",
                    "RelatedTask":"Smoking",
                    "Value": [
                        {
                            "Local": "en-en",
                            "Text": "Yes"
                        },
                        {
                            "Local": "ru-ru",
                            "Text": "Да"
                        }
                    ],
                },
                {
                    "Name": "No",
                    "Value": [
                        {
                            "Local": "en-en",
                            "Text": "No"
                        },
                        {
                            "Local": "ru-ru",
                            "Text": "Нет"
                        }
                    ],
                }]
        },
        {
            "Name": "DrinkCofee",
            "QuestionType": "SingleSelect",
            "DataType": "string",
            "DefaultValue": null,
            "Title": [{
                "Local": "en-en",
                "Text": "Do you drink coffee? :"
            },
            {
                "Local": "ru-ru",
                "Text": "Вы пьете кофе??"
            }
            ],
            "Description": [
            ],
            "Validations": [],
            "Answers": [
                {
                    "Name": "Yes",
                    "RelatedQuestionnaire":"DrinkingCoffee",
                    "Value": [
                        {
                            "Local": "en-en",
                            "Text": "Yes"
                        },
                        {
                            "Local": "ru-ru",
                            "Text": "Да"
                        }
                    ],
                },
                {
                    "Name": "No",
                    "Value": [
                        {
                            "Local": "en-en",
                            "Text": "No"
                        },
                        {
                            "Local": "ru-ru",
                            "Text": "Нет"
                        }
                    ],
                }]
        },
        {
            "Name": "DrinkAlcohol",
            "QuestionType": "SingleSelect",
            "DataType": "string",
            "DefaultValue": null,
            "Title": [{
                "Local": "en-en",
                "Text": "Do you drink alcohol? :"
            },
            {
                "Local": "ru-ru",
                "Text": "Вы употребляете алкаголь?"
            }
            ],
            "Description": [
            ],
            "Validations": [],
            "Answers": [
                {
                    "Name": "Yes",
                    "RelatedQuestionnaire":"DrinkingAlcohol",
                    "Value": [
                        {
                            "Local": "en-en",
                            "Text": "Yes"
                        },
                        {
                            "Local": "ru-ru",
                            "Text": "Да"
                        }
                    ],
                },
                {
                    "Name": "No",
                    "Value": [
                        {
                            "Local": "en-en",
                            "Text": "No"
                        },
                        {
                            "Local": "ru-ru",
                            "Text": "Нет"
                        }
                    ],
                }]
        },
    ]
}