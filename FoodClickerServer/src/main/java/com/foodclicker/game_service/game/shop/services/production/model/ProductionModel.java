package com.foodclicker.game_service.game.shop.services.production.model;

import com.foodclicker.game_service.game.shop.services.production.entity.ProductionDocument;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@NoArgsConstructor
public class ProductionModel {
    private Integer uid;
    private int level;
    private int gps;
    private int gpc;
    private int nextLevelPrice;
    public ProductionModel(ProductionDocument document, int level, int nextLevelPrice) {
        this.uid = document.getUid();
        this.level = level;
        this.nextLevelPrice = nextLevelPrice;
        this.gps = document.getGpsPerLevel() == null ? 0 : document.getGpsPerLevel() * (level + 1);
        this.gpc =  document.getGpcPerLevel() == null ? 0 :document.getGpcPerLevel() * (level + 1);
    }
    
}
