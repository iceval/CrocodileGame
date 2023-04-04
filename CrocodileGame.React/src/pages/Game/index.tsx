import { base } from '../../data/cardBase'
import { useState } from 'react'
import { CardProps } from '../../interfaces/card.interface'
import { NavLink } from 'react-router-dom'

import CardItem from '../../components/CardItem'

import './styles.scss'

export const Game = () => {
  const [cardList, setCardList] = useState<CardProps[]>(base)
  const [card, setCard] = useState<CardProps>()

  return(
    <div className="game">
      <div className="game__menu">
        <NavLink className="game__button" to="/">Back</NavLink>
      </div>
      <div className="game__card">
        {cardList.map(card => (
          <div key={card.id} className="game__card-content">
            <CardItem cardId={card.id} isShowCardButton={false} />
            <div className="game__card-buttons">
            </div>
          </div>
        ))}
      </div>
      <div className="game__buttons">
        <button className="game__button game__button-hide"></button>
        <button className="game__button game__button-subtract"></button>
        <button className="game__button game__button-add"></button>
      </div>
    </div>
  )
}