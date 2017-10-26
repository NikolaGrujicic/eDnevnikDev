﻿html {
    background-image: url('1.jpg');
    background-attachment: scroll;
    background-repeat: no-repeat;
    background-size: cover;
    height: 100vh;
}

.loader {
    position: fixed;
    top: 50%;
    left: 50%;
    margin-top: -25px;
    margin-left: -25px;
    border: 10px solid #DDDBAB;
    border-top: 10px solid #6DA385;
    border-bottom: 10px solid #6DA385;
    border-radius: 50%;
    width: 50px;
    height: 50px;
    animation: spin 1.2s linear infinite;
    background-color: #1F3C44;
}

@keyframes spin {
    0% {
        transform: rotate(0deg);
}

25% {
    transform: rotate(180deg) scale(1.4);
border-top: 10px solid #102230;
border-bottom: 10px solid #102230;
transition: 0.7s;
}

50% {
    transform: rotate(360deg);
}

100% {
    transform: rotate(360deg) scale(1);
}
}
