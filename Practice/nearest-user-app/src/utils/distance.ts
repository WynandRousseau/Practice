function toRadians(degrees: number): number {
    return (degrees * Math.PI) / 180;
}

function haversineDistance(lat1: number, lon1: number, lat2: number, lon2: number): number {
    const R = 6371; // Radius of Earth in kilometers
    const dLat = toRadians(lat2 - lat1);
    const dLon = toRadians(lon2 - lon1);

    const a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(toRadians(lat1)) * Math.cos(toRadians(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));

    return R * c; // Distance in kilometers
}

export function findNearestUser(hotel: { lat: number, lng: number }, users: any[]) {
    let nearestUser = null;
    let minDistance = Infinity;

    users.forEach(user => {
        const userLat = parseFloat(user.address.geo.lat);
        const userLng = parseFloat(user.address.geo.lng);
        const distance = haversineDistance(hotel.lat, hotel.lng, userLat, userLng);

        if (distance < minDistance) {
            minDistance = distance;
            nearestUser = user;
        }
    });

    return { nearestUser, minDistance };
}


