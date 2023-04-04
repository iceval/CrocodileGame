import { ChangeEvent, FC, useState } from 'react'
import { TopicProps } from '../../interfaces/topic.interface'

import './styles.scss'

interface FormProps {
    showTopicModal: () => void
    topic: TopicProps | undefined
}

const TopicForm :FC<FormProps> = ({ showTopicModal, topic }) => {
    const [name, setName] = useState<string>('')

    const postData = async () => {
        console.log(name)
    }
    
    const updateData = async () => {
        console.log(topic)
    }

    const handleSubmit = () => {
        showTopicModal()

        console.log(topic)

        if (name !== undefined) updateData()
        else postData()
    }

    const handleBack = () => {
        showTopicModal()
    }

    const handleChangeTopic = (event: ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value)
    }

    return (
        <form className="form" onSubmit={handleSubmit}>
            <div className="form__box">
            <button className="form__back" onClick={handleBack} />
            <div className="form__title form__cell">Topic</div>
            <input
                name="topic"
                type="text"
                placeholder="Write topic..."
                value={name}
                onChange={handleChangeTopic}
                className="form__input form__cell"
            />
            <button type="submit" className="form__button">
                Send
            </button>
            </div>
        </form>
    )
}

export default TopicForm
