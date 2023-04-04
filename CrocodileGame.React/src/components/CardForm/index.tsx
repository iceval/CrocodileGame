import { ChangeEvent, FC, useState } from 'react'
import { CardProps } from "../../interfaces/card.interface"

import './styles.scss'

interface FormProps {
    showCardModal: () => void
    card: CardProps | undefined
}

const CardForm :FC<FormProps> = ({ showCardModal, card }) => {
    const [word, setWord] = useState<string>(card?.word ?? '')

    const postData = async () => {
        console.log(word)
    }
    
    const updateData = async () => {
        await fetch(process.env.REACT_APP_API + 'cards/' + card?.id, {
            method: 'PUT',
            body: JSON.stringify({ word }),
            headers: { 'Content-Type': 'application/json' },
        })
    }

    const handleSubmit = () => {
        showCardModal()

        console.log(card?.id)

        if (card !== undefined) updateData()
        else postData()
    }

    const handleBack = () => {
        showCardModal()
    }

    const handleChangeWord = (event: ChangeEvent<HTMLInputElement>) => {
        setWord(event.target.value)
    }

    return (
        <form className="form" onSubmit={handleSubmit}>
            <div className="form__box">
            <button className="form__back" onClick={handleBack} />
            <div className="form__title form__cell">Word</div>
            <input
                name="word"
                type="text"
                placeholder="Write word..."
                value={word}
                onChange={handleChangeWord}
                className="form__input form__cell"
            />
            <button type="submit" className="form__button">
                Send
            </button>
            </div>
        </form>
    )
}

export default CardForm
