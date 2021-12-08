redirectToLocation = (location) => {
    return window.location.href = location;
}

getParameterFromUrl = (parameterName) => {
    const url = new URL(window.location.href);
    const searchParams = new URLSearchParams(url.search);
    return searchParams.get(parameterName);
}