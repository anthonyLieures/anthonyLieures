# Setup GitLab Runner

## Install GitLab runner

```bash
# Install Curl
sudo apt install curl

# Download the binary for your system
sudo curl -L --output /usr/local/bin/gitlab-runner https://gitlab-runner-downloads.s3.amazonaws.com/latest/binaries/gitlab-runner-linux-amd64

# Give it permissions to execute
sudo chmod +x /usr/local/bin/gitlab-runner

# Create a GitLab CI user
sudo useradd --comment 'GitLab Runner' --create-home gitlab-runner --shell /bin/bash

# Install and run as service
sudo gitlab-runner install --user=gitlab-runner --working-directory=/home/gitlab-runner
sudo gitlab-runner start
```

## Register Runner

```bash
sudo gitlab-runner register --url https://gitlab.com/ --registration-token So6ZzswCXf2erH2xMf5K
```

Docker executor with this Image : [gableroux/unity3d:2019.4.11f1-windows](https://hub.docker.com/r/gableroux/unity3d/tags?page=1&name=2019.4.11)
