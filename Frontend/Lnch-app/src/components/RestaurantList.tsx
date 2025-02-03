import React, { useEffect, useState } from "react";
import styles from "./RestaurantList.module.css";

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
    <div className={styles.restaurantContainer}>
      {restaurants.map((restaurant) => (
        <div key={restaurant.id} className={styles.restaurantCard}>
          <h3 className={styles.restaurantName}>{restaurant.name}</h3>
          <p className={styles.restaurantLocation}>
            Location: {restaurant.location}
          </p>
        </div>
      ))}
    </div>
  );
};

export default RestaurantList;
