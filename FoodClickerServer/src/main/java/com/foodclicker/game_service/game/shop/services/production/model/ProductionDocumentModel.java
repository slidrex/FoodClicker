package com.foodclicker.game_service.game.shop.services.production.model;

import com.foodclicker.game_service.game.shop.services.production.entity.ProductionDocument;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class ProductionDocumentModel {
    private int uid;
    private int price;
    private int baseGpc;
    private int baseGps;
    public ProductionDocumentModel(ProductionDocument document) {
        this.uid = document.getUid();
        this.price = document.getBasePrice();
        this.baseGpc = document.getGpcPerLevel() == null ? 0 : document.getGpcPerLevel();
        this.baseGps = document.getGpsPerLevel() == null ? 0 : document.getGpsPerLevel();
    }
}
