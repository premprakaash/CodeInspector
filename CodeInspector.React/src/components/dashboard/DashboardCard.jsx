import { Card, CardContent, Typography } from "@mui/material";

export default function DashboardCard({
    title,
    value,
    color
}) {
    return (
        <Card
            elevation={3}
            sx={{
                borderLeft: `6px solid ${color}`,
                borderRadius: 3
            }}
        >
            <CardContent>
                <Typography
                    color="text.secondary"
                    variant="subtitle2"
                >
                    {title}
                </Typography>

                <Typography
                    variant="h3"
                    sx={{
                        mt: 2,
                        fontWeight: "bold"
                    }}
                >
                    {value}
                </Typography>
            </CardContent>
        </Card>
    );
}