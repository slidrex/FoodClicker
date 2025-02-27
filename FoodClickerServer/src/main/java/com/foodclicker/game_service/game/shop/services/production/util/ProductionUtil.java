package com.foodclicker.game_service.game.shop.services.production.util;

import org.springframework.stereotype.Service;

@Service
public class ProductionUtil {
    public int getProductionPrice(int basePrice, int level) {
        return (int)Math.round((basePrice * Math.pow(1.15d, level)));
    }
}
