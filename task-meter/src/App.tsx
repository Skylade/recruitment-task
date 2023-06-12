import { useState } from "react";
import { Button, Input } from "antd";
import "./App.css";
import Task from "./TaskInterface";

function App() {
    const [tasks, setTasks] = useState<Task[] | []>([]);
    const [currentTaskName, setCurrentTaskName] = useState<string>();
    const [currentTask, setCurrentTask] = useState<Task>();

    const onTaskChange = (values: any) => {
        setCurrentTaskName(values.target.value);
    };

    const startNewTask = () => {
        const task = {} as Task;
        task.name = currentTaskName!;
        task.start = new Date().toLocaleString();
        setCurrentTask(task);
    };

    const endNewTask = () => {
        const task = currentTask;

        if (task !== undefined && task !== null) {
            task.stop = new Date().toLocaleString();
            setTasks((tasks) => [...tasks, task]);
        }
    };

    return (
        <>
            <div className="text-7xl font-bold p-5">
                <span className="title-gradient">Welcome to Task-meter</span>{" "}
            </div>
            <div className="flex justify-center">
                <div className="p-5 w-1/2">
                    <Input
                        placeholder="Enter your task name here"
                        onChange={onTaskChange}
                    />

                    <div className="flex justify-evenly p-5">
                        <Button
                            onClick={startNewTask}
                            style={{
                                background: "#747bff",
                                borderColor: "#747bff",
                                color: "#ffffff",
                                fontWeight: "bold",
                            }}
                        >
                            Start task
                        </Button>
                        <Button
                            onClick={endNewTask}
                            style={{
                                background: "#2c2c30",
                                borderColor: "#45454b",
                                color: "#ffffff",
                                fontWeight: "bold",
                            }}
                        >
                            End task
                        </Button>
                    </div>
                </div>
                <div className="text-white p-5 w-1/2">
                    <span className="font-bold text-2xl">Tasks history:</span>
                    <ul>
                        <div>
                            {tasks.map((o) => (
                                <li key={o.name}>
                                    {o.name} {o.start} {o.stop}
                                </li>
                            ))}
                        </div>
                    </ul>
                </div>
            </div>
        </>
    );
}

export default App;
