import React, { useEffect, useState } from "react";

interface Restaurant {
  Id: number;
  Name: string;
  Location: string;
}

const RestaurantList: React.FC = () => {
  const [restaurants, setRestaurants] = useState<Restaurant[]>([]);

  useEffect(() => {
    fetch("http://localhost:5076/api/My")
      .then((response) => response.json())
      .then((data) => {
        setRestaurants(data);
      })
      .catch((error) => {
        console.error("Error fetching restaurants:", error);
      });
  }, []);

  return (
    <div>
      {restaurants.map((restaurant) => (
        <div key={restaurant.Id}>
          <h3>{restaurant.Name}</h3>
          <p>Location: {restaurant.Location}</p>
        </div>
      ))}
    </div>
  );
};

export default RestaurantList;
