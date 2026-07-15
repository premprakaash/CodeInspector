import { useNavigate } from "react-router-dom";
import {
    Button,
    Card,
    CardContent,
    Container,
    Typography
} from "@mui/material";

export default function Login() {

    const navigate = useNavigate();

    return (

        <Container
            maxWidth="sm"
            sx={{
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
                height: "100vh"
            }}
        >

            <Card sx={{ width: 550 }}>

                <CardContent sx={{ p: 5, textAlign: "center" }}>

                    <Typography variant="h3">
                        CodeInspector
                    </Typography>

                    <Typography sx={{ mt: 2 }}>
                        AI Powered Static Code Analysis
                    </Typography>

                    <Button
                        variant="contained"
                        size="large"
                        sx={{ mt: 5 }}
                        onClick={() => navigate("/dashboard")}
                    >
                        Continue with GitHub
                    </Button>

                </CardContent>

            </Card>

        </Container>

    );

}