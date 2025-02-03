import React, { useEffect, useState } from "react";

interface Restaurant {
  id: number;
  name: string;
  location: string;
}

const RestaurantList: React.FC = () => {
  const [restaurants, setRestaurants] = useState<Restaurant[]>([]);

  useEffect(() => {
    fetch("http://localhost:5076/api/My")
      .then((response) => response.json())
      .then((data) => {
        console.log("API Response:", data);
        setRestaurants(data);
      })
      .catch((error) => {
        console.error("Error fetching restaurants:", error);
      });
  }, []);

  return (
    <div>
      {restaurants.map((restaurant) => (
        <div key={restaurant.id}>
          <h3>{restaurant.name}</h3>
          <p>Location: {restaurant.location}</p>
        </div>
      ))}
    </div>
  );
};

export default RestaurantList;
