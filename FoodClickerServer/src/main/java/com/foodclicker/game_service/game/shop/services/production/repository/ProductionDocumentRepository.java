package com.foodclicker.game_service.game.shop.services.production.repository;

import com.foodclicker.game_service.game.shop.services.production.entity.ProductionDocument;
import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.Optional;

public interface ProductionDocumentRepository extends MongoRepository<ProductionDocument, String> {
    Optional<ProductionDocument> getByUid(int uid);
}
