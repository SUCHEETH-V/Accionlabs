pipeline {
    agent any
    environment {
        DOCKER_IMAGE = 'sucheeth/nginx:1.19'
        DOCKER_CREDENTIALS_ID = 'dockerhub-credentials' 
        KUBECONFIG_CREDENTIALS_ID = 'kubeconfig' 
    }
    stages {
        stage('Code Checkout') {
            steps {
                git clone https://github.com/SUCHEETH-V/phData.git
            }
        }
        stage('Build Docker Image') {
            steps {
                script {
                    docker.build(DOCKER_IMAGE)
                }
            }
        }
        stage('Trivy Image Scan') {
            steps {
                sh "trivy image --exit-code 1 --severity CRITICAL,HIGH ${DOCKER_IMAGE} || true"
            }
        }
        stage('Push Docker Image') {
            steps {
                withCredentials([usernamePassword(credentialsId: "${DOCKER_CREDENTIALS_ID}", usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD')]) {
                    sh """
                        echo "$PASSWORD" | docker login -u "$USERNAME" --password-stdin
                        docker push ${DOCKER_IMAGE}
                    """
                }
            }
        }

        stage('Deploy to Kubernetes') {
            steps {
                withCredentials([file(credentialsId: "${KUBECONFIG_CREDENTIALS_ID}", variable: 'KUBECONFIG')]) {
                    sh '''
                        export KUBECONFIG=$KUBECONFIG
                        kubectl apply -f k8s/statefulset.yaml
                    '''
                }
            }
        }
    }
}
