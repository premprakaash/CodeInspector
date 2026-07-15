import MainLayout from "../layouts/MainLayout";
import DashboardCard from "../components/dashboard/DashboardCard";

import {
    Grid,
    Typography,
    Paper
} from "@mui/material";

export default function Dashboard() {

    return (

        <MainLayout>

            <Typography
                variant="h4"
                sx={{ mb: 4 }}
            >
                Dashboard
            </Typography>

            <Grid container spacing={3}>

                <Grid size={{ xs: 12, md: 3 }}>
                    <DashboardCard
                        title="Files"
                        value="1250"
                        color="#2196f3"
                    />
                </Grid>

                <Grid size={{ xs: 12, md: 3 }}>
                    <DashboardCard
                        title="Issues"
                        value="140"
                        color="#ff9800"
                    />
                </Grid>

                <Grid size={{ xs: 12, md: 3 }}>
                    <DashboardCard
                        title="Critical"
                        value="4"
                        color="#f44336"
                    />
                </Grid>

                <Grid size={{ xs: 12, md: 3 }}>
                    <DashboardCard
                        title="High"
                        value="20"
                        color="#9c27b0"
                    />
                </Grid>

                <Grid size={{ xs: 12, md: 8 }}>

                    <Paper
                        sx={{
                            p: 3,
                            height: 350,
                            borderRadius: 3
                        }}
                    >
                        <Typography variant="h6">
                            Scan History
                        </Typography>

                        <Typography sx={{ mt: 3 }}>
                            Chart will be added here.
                        </Typography>

                    </Paper>

                </Grid>

                <Grid size={{ xs: 12, md: 4 }}>

                    <Paper
                        sx={{
                            p: 3,
                            height: 350,
                            borderRadius: 3
                        }}
                    >
                        <Typography variant="h6">
                            Recent Scans
                        </Typography>

                        <Typography sx={{ mt: 2 }}>
                            Banking API
                        </Typography>

                        <Typography>
                            Inventory
                        </Typography>

                        <Typography>
                            HRMS
                        </Typography>

                    </Paper>

                </Grid>

            </Grid>

        </MainLayout>

    );

}