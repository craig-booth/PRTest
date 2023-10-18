pipeline {
    	
	agent any

	environment {
		PROJECT      = './PRTest/PRTest.csproj'
		TEST_PROJECT = './UnitTests/UnitTests.csproj'
    }

    stages {
		stage('Build') {
			agent { 
				docker { 
					image 'mcr.microsoft.com/dotnet/sdk:7.0-alpine' 
					reuseNode true
				}
			}

			stages {
				stage('Build') {
					steps {
						sh "dotnet build ${PROJECT} --configuration Release"
					}
				}

				stage('Test') {
					steps {
						sh "dotnet test ${TEST_PROJECT} --configuration Release --logger trx --results-directory ./testresults"
					}
					post {
						always {
							xunit (
								thresholds: [ skipped(failureThreshold: '0'), failed(failureThreshold: '0') ],
								tools: [ MSTest(pattern: 'testresults/*.trx') ]
								)
						}
					}
				}

				stage('Publish') {
					steps {
						sh "dotnet publish ${PROJECT} --configuration Release --output ./deploy"
					}
				}
			}

		}
    }
	
	post {
		success {
			cleanWs()
		}
	}
}