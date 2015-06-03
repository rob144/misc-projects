<?php 
header("Access-Control-Allow-Origin: *");
header('Content-Type: application/json');
echo '{
    "userrisk": {
        "MFTest": {
            "Admin": "MF_ADMIN", 
            "Dsl": "NDA", 
            "DslInherited": "NDA", 
            "DslUsage": "NDA", 
            "Feed": -1, 
            "Group": "MFTest", 
            "LimitID": "33", 
            "Market": -1, 
            "Nop": 300000000, 
            "NopInherited": "NDA", 
            "NopUsage": 0, 
            "ParentGroup": null, 
            "Pending": "NDA", 
            "PendingInherited": "NDA", 
            "PendingUsage": "NDA", 
            "Position": "NDA", 
            "PositionInherited": "NDA", 
            "PositionUsage": "NDA", 
            "Single": "NDA", 
            "Throttle": "NDA", 
            "children": {
                "MFTestA": {
                    "Admin": "MF_ADMIN", 
                    "Dsl": "NDA", 
                    "DslInherited": "NDA", 
                    "DslUsage": "NDA", 
                    "Feed": -1, 
                    "Group": "MFTestA", 
                    "LimitID": "30", 
                    "Market": -1, 
                    "Nop": 120000000, 
                    "NopInherited": 300000000, 
                    "NopUsage": 0, 
                    "ParentGroup": null, 
                    "Pending": "NDA", 
                    "PendingInherited": "NDA", 
                    "PendingUsage": "NDA", 
                    "Position": "NDA", 
                    "PositionInherited": "NDA", 
                    "PositionUsage": "NDA", 
                    "Single": "NDA", 
                    "Throttle": "NDA", 
                    "children": {
                        "TestUser1": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": "NDA", 
                            "DslInherited": "NDA", 
                            "DslUsage": "NDA", 
                            "Feed": -1, 
                            "Group": "TestUser1", 
                            "LimitID": "23", 
                            "Market": -1, 
                            "Nop": 50000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 0, 
                            "ParentGroup": null, 
                            "Pending": "NDA", 
                            "PendingInherited": "NDA", 
                            "PendingUsage": "NDA", 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": "NDA", 
                            "Throttle": "NDA"
                        }, 
                        "TestUser2": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": "NDA", 
                            "DslInherited": "NDA", 
                            "DslUsage": "NDA", 
                            "Feed": -1, 
                            "Group": "TestUser2", 
                            "LimitID": "24", 
                            "Market": -1, 
                            "Nop": 50000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 0, 
                            "ParentGroup": null, 
                            "Pending": "NDA", 
                            "PendingInherited": "NDA", 
                            "PendingUsage": "NDA", 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": "NDA", 
                            "Throttle": "NDA"
                        }, 
                        "TestUser3": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": "NDA", 
                            "DslInherited": "NDA", 
                            "DslUsage": "NDA", 
                            "Feed": -1, 
                            "Group": "TestUser3", 
                            "LimitID": "25", 
                            "Market": -1, 
                            "Nop": 50000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 0, 
                            "ParentGroup": null, 
                            "Pending": "NDA", 
                            "PendingInherited": "NDA", 
                            "PendingUsage": "NDA", 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": "NDA", 
                            "Throttle": "NDA"
                        }, 
                        "default_factory": {}
                    }, 
                    "default_factory": {}
                }, 
                "MFTestB": {
                    "Admin": "MF_ADMIN", 
                    "Dsl": "NDA", 
                    "DslInherited": "NDA", 
                    "DslUsage": "NDA", 
                    "Feed": -1, 
                    "Group": "MFTestB", 
                    "LimitID": "31", 
                    "Market": -1, 
                    "Nop": 120000000, 
                    "NopInherited": 300000000, 
                    "NopUsage": 3586539.796, 
                    "ParentGroup": null, 
                    "Pending": "NDA", 
                    "PendingInherited": "NDA", 
                    "PendingUsage": "NDA", 
                    "Position": "NDA", 
                    "PositionInherited": "NDA", 
                    "PositionUsage": "NDA", 
                    "Single": "NDA", 
                    "Throttle": "NDA", 
                    "children": {
                        "TestUser4": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": 100000000, 
                            "DslInherited": "NDA", 
                            "DslUsage": {
                                "2015-3-13": 14000000
                            }, 
                            "Feed": -1, 
                            "Group": "TestUser4", 
                            "LimitID": "14", 
                            "Market": -1, 
                            "Nop": 10000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 3586539.796, 
                            "ParentGroup": null, 
                            "Pending": 5000000, 
                            "PendingInherited": "NDA", 
                            "PendingUsage": 0, 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": 3000000, 
                            "Throttle": 2
                        }, 
                        "TestUser5": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": "NDA", 
                            "DslInherited": "NDA", 
                            "DslUsage": "NDA", 
                            "Feed": -1, 
                            "Group": "TestUser5", 
                            "LimitID": "27", 
                            "Market": -1, 
                            "Nop": 50000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 0, 
                            "ParentGroup": null, 
                            "Pending": "NDA", 
                            "PendingInherited": "NDA", 
                            "PendingUsage": "NDA", 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": "NDA", 
                            "Throttle": "NDA"
                        }, 
                        "TestUser6": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": "NDA", 
                            "DslInherited": "NDA", 
                            "DslUsage": "NDA", 
                            "Feed": -1, 
                            "Group": "TestUser6", 
                            "LimitID": "28", 
                            "Market": -1, 
                            "Nop": 50000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 0, 
                            "ParentGroup": null, 
                            "Pending": "NDA", 
                            "PendingInherited": "NDA", 
                            "PendingUsage": "NDA", 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": "NDA", 
                            "Throttle": "NDA"
                        }, 
                        "default_factory": {}
                    }, 
                    "default_factory": {}
                }, 
                "MFTestC": {
                    "Admin": "MF_ADMIN", 
                    "Dsl": "NDA", 
                    "DslInherited": "NDA", 
                    "DslUsage": "NDA", 
                    "Feed": -1, 
                    "Group": "MFTestC", 
                    "LimitID": "32", 
                    "Market": -1, 
                    "Nop": 120000000, 
                    "NopInherited": 300000000, 
                    "NopUsage": 0, 
                    "ParentGroup": null, 
                    "Pending": "NDA", 
                    "PendingInherited": "NDA", 
                    "PendingUsage": "NDA", 
                    "Position": "NDA", 
                    "PositionInherited": "NDA", 
                    "PositionUsage": "NDA", 
                    "Single": "NDA", 
                    "Throttle": "NDA", 
                    "children": {
                        "TestUser10": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": "NDA", 
                            "DslInherited": "NDA", 
                            "DslUsage": "NDA", 
                            "Feed": -1, 
                            "Group": "TestUser10", 
                            "LimitID": "12", 
                            "Market": -1, 
                            "Nop": 50000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 0, 
                            "ParentGroup": null, 
                            "Pending": 20000000, 
                            "PendingInherited": "NDA", 
                            "PendingUsage": 0, 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": 20000000, 
                            "Throttle": "NDA"
                        }, 
                        "TestUser7": {
                            "Admin": "MF_ADMIN", 
                            "Dsl": "NDA", 
                            "DslInherited": "NDA", 
                            "DslUsage": "NDA", 
                            "Feed": -1, 
                            "Group": "TestUser7", 
                            "LimitID": "29", 
                            "Market": -1, 
                            "Nop": 50000000, 
                            "NopInherited": 120000000, 
                            "NopUsage": 0, 
                            "ParentGroup": null, 
                            "Pending": "NDA", 
                            "PendingInherited": "NDA", 
                            "PendingUsage": "NDA", 
                            "Position": "NDA", 
                            "PositionInherited": "NDA", 
                            "PositionUsage": "NDA", 
                            "Single": "NDA", 
                            "Throttle": "NDA"
                        }, 
                        "TestUser8": {
                            "default_factory": {}
                        }, 
                        "TestUser9": {
                            "default_factory": {}
                        }, 
                        "default_factory": {}
                    }, 
                    "default_factory": {}
                }, 
                "TestUser": {
                    "Admin": "MF_ADMIN", 
                    "Dsl": 250000000, 
                    "DslInherited": "NDA", 
                    "DslUsage": {
                        "Cash": 5117130
                    }, 
                    "Feed": -1, 
                    "Group": "TestUser", 
                    "LimitID": "13", 
                    "Market": -1, 
                    "Nop": 75000000, 
                    "NopInherited": 300000000, 
                    "NopUsage": 0, 
                    "ParentGroup": null, 
                    "Pending": "NDA", 
                    "PendingInherited": "NDA", 
                    "PendingUsage": "NDA", 
                    "Position": "NDA", 
                    "PositionInherited": "NDA", 
                    "PositionUsage": "NDA", 
                    "Single": 13000000, 
                    "Throttle": "NDA"
                }, 
                "default_factory": {}
            }, 
            "default_factory": {}
        }, 
        "default_factory": {}
    }
}';
?>
